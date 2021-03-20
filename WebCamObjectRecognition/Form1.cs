using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using Alturos.Yolo;
using Alturos.Yolo.Model;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WebCamObjectRecognition
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        // create motion detector
        MotionDetector detector = new MotionDetector(
            new TwoFramesDifferenceDetector(),
            new MotionBorderHighlighting());

        static bool isMotionDetectorOn = false;
        static bool isAlarmNotificationsOn = false;
        static bool isMessageSend = false;
        private string fileName = String.Empty;

        YoloWrapper yolo = new YoloWrapper(
            "yolo-weights\\yolov3.cfg", 
            "yolo-weights\\yolov3.weights", 
            "yolo-weights\\coco.names"
            );

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count != 0)
            {
                foreach (FilterInfo cam in videoDevices)
                {
                    camerasStripComboBox.Items.Add(cam.Name);
                }
                camerasStripComboBox.SelectedIndex = 0;                
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (camerasStripComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать камеру!", "Ошибка!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                videoSource = new VideoCaptureDevice(videoDevices[camerasStripComboBox.SelectedIndex].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
                CameraOn(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при попытке подключения к камере!\nОписание ошибки: " + ex.Message, "Ошибка!", MessageBoxButtons.OK);
                return;

            }
        }

        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            if (isMessageSend)
            {
                videoSource.SignalToStop();
                return;
            }

            if (isMotionDetectorOn)
            {
                float motion_lvl;
                motion_lvl = detector.ProcessFrame(eventArgs.Frame);

                // Если включено "Уведомлять о движении на камере на почту"
                if (isAlarmNotificationsOn)
                {
                    if (motion_lvl > 0.1f)
                    {
                        // Проверяем, существует ли папка catchPhotos
                        if (!Directory.Exists(@".\\catchPhotos"))
                        {
                            // Если нет, создаём
                            Directory.CreateDirectory(@".\\catchPhotos");
                        }

                        // Отлавливаем и сохраняем кадр на диск
                        pictureCameraBox.Image.Save($".\\catchPhotos\\сatchPhoto{motion_lvl}.bmp", ImageFormat.Bmp);

                        // Составляем и отправляем письмо

                        #region Составление и отправка письма
                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("Camera App", "kirill.rubinov@yandex.ru"));
                        message.To.Add(new MailboxAddress("Admin", "sakoff.kirill@yandex.ru"));
                        message.Subject = "Alarm";

                        message.Body = new TextPart("plain")
                        {
                            Text = @"Hey men,

                            On your camera detected some motion

                            -- Your app"
                        };

                        // create an image attachment for the file located at path
                        var attachment = new MimePart("image", "gif")
                        {
                            Content = new MimeContent(File.OpenRead($".\\catchPhotos\\сatchPhoto{motion_lvl}.bmp")),
                            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = Path.GetFileName($".\\catchPhotos\\сatchPhoto{motion_lvl}.bmp")
                        };

                        // now create the multipart/mixed container to hold the message text and the
                        // image attachment
                        var multipart = new Multipart("mixed");
                        multipart.Add(message.Body);
                        multipart.Add(attachment);

                        // now set the multipart/mixed as the message body
                        message.Body = multipart;

                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.yandex.ru", 465, true);

                            // Note: only needed if the SMTP server requires authentication
                            client.Authenticate("example@yandex.ru", "examplepassword");

                            client.Send(message);
                            client.Disconnect(true);
                        }

                        isMessageSend = true;
                        #endregion

                    }
                }                
            }

            Bitmap tmpBMP = (Bitmap)eventArgs.Frame.Clone();
            tmpBMP.RotateFlip(RotateFlipType.RotateNoneFlipX);
            try
            {
                pictureCameraBox.Image = tmpBMP;
            }
            catch
            {

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                Environment.Exit(0);
            }
        }

        private void recognitionButton_Click(object sender, EventArgs e)
        {
            if (videoSource != null || pictureCameraBox.Image != null)
            {
                if (videoSource != null)
                    videoSource.Stop();

                MemoryStream memoryStream = new MemoryStream();
                pictureCameraBox.Image.Save(memoryStream, ImageFormat.Bmp);
                List<YoloItem> items = yolo.Detect(memoryStream.ToArray()).ToList<YoloItem>();

                Bitmap finalImage = new Bitmap(pictureCameraBox.Image);

                Graphics graph = Graphics.FromImage(finalImage);
                Font font = new Font("Consolas", 20, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Yellow);

                foreach (YoloItem item in items)
                {
                    Point rectPoint = new Point(item.X, item.Y);
                    Size rectSize = new Size(item.Width, item.Height);

                    Rectangle rect = new Rectangle(rectPoint, rectSize);

                    Pen pen = new Pen(Color.Yellow, 2);

                    graph.DrawRectangle(pen, rect);
                    graph.DrawString(item.Type, font, brush, rectPoint);
                }

                pictureCameraBox.Image = finalImage;
            }
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
                videoSource.Start();
        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.Stop();
                isMessageSend = false;
                CameraOn(false);
            }
        }

        private void CameraOn(bool is_on)
        {
            if (!is_on)
                videoSource = null;

            startButton.Enabled = !is_on;
            camerasStripComboBox.Enabled = !is_on;
            repeatButton.Enabled = !is_on;
        }
        
        private void modeButton_Click(object sender, EventArgs e)
        {
            isMotionDetectorOn = !isMotionDetectorOn;
            if (isMotionDetectorOn)
            {
                modeButton.BackColor = SystemColors.ActiveBorder;
            }
            else if (!isMotionDetectorOn)
            {
                modeButton.BackColor = DefaultBackColor;
            }
        }

        private void pictureCameraBox_DoubleClick(object sender, EventArgs e)
        {
            pictureCameraBox.Image = null;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                pictureCameraBox.Image = Image.FromFile(fileName);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            try
            {
                pictureCameraBox.Image = Image.FromFile(files[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при импортировании изображения.", "Ошибка!", MessageBoxButtons.OK);
                return;
            }            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case (Keys.V | Keys.Control):
                    {
                        if (Clipboard.ContainsImage())
                        {
                            pictureCameraBox.Image = Clipboard.GetImage();
                        }
                        else
                        {

                            string[] data = 
                                (string[])Clipboard.GetData(DataFormats.FileDrop);

                            try
                            {
                                pictureCameraBox.Image = Image.FromFile(data[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ошибка при импортировании изображения.", "Ошибка!", MessageBoxButtons.OK);
                                return;
                            }
                        }                        
                        break;
                    }

                case (Keys.C | Keys.Control):
                    {
                        try
                        {
                            Clipboard.SetImage(pictureCameraBox.Image);
                            //MessageBox.Show("Картинка сохранена в буфер обмена.", "Успешно!", MessageBoxButtons.OK);
                        }
                        catch (Exception)
                        {
                            
                        }
                        break;
                    }
            }
        }

        private void repeatButton_Click(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count != 0)
            {
                foreach (FilterInfo cam in videoDevices)
                {
                    camerasStripComboBox.Items.Add(cam.Name);
                }
                camerasStripComboBox.SelectedIndex = 0;
            }
            if (videoDevices.Count == 0)
            {
                camerasStripComboBox.Items.Clear();
                camerasStripComboBox.Text = "";
            }
        }

        private void alarmButton_Click(object sender, EventArgs e)
        {
            isAlarmNotificationsOn = !isAlarmNotificationsOn;
            if (isAlarmNotificationsOn)
            {
                alarmButton.BackColor = SystemColors.ActiveBorder;
            }
            else if (!isAlarmNotificationsOn)
            {
                alarmButton.BackColor = DefaultBackColor;
            }
        }
    }
}
