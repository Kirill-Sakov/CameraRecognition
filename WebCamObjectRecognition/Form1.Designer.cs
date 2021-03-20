namespace WebCamObjectRecognition
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.camerasStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.repeatButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.modeButton = new System.Windows.Forms.ToolStripButton();
            this.alarmButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.recognitionButton = new System.Windows.Forms.ToolStripButton();
            this.resumeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.pictureCameraBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCameraBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.camerasStripComboBox,
            this.repeatButton,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.startButton,
            this.toolStripSeparator2,
            this.modeButton,
            this.alarmButton,
            this.toolStripSeparator3,
            this.recognitionButton,
            this.resumeButton,
            this.toolStripSeparator4,
            this.openButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1280, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 22);
            this.toolStripLabel1.Text = "Доступные камеры:";
            // 
            // camerasStripComboBox
            // 
            this.camerasStripComboBox.Name = "camerasStripComboBox";
            this.camerasStripComboBox.Size = new System.Drawing.Size(160, 25);
            // 
            // repeatButton
            // 
            this.repeatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.repeatButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(23, 22);
            this.repeatButton.Text = "↻";
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton1.Text = "Stop";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(35, 22);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // modeButton
            // 
            this.modeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.modeButton.Image = ((System.Drawing.Image)(resources.GetObject("modeButton.Image")));
            this.modeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(140, 22);
            this.modeButton.Text = "Отслеживать движение";
            this.modeButton.Click += new System.EventHandler(this.modeButton_Click);
            // 
            // alarmButton
            // 
            this.alarmButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.alarmButton.Image = ((System.Drawing.Image)(resources.GetObject("alarmButton.Image")));
            this.alarmButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alarmButton.Name = "alarmButton";
            this.alarmButton.Size = new System.Drawing.Size(250, 22);
            this.alarmButton.Text = "Уведомлять о движении с камеры на почту";
            this.alarmButton.ToolTipText = "Включить уведомления";
            this.alarmButton.Click += new System.EventHandler(this.alarmButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // recognitionButton
            // 
            this.recognitionButton.BackColor = System.Drawing.SystemColors.Info;
            this.recognitionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.recognitionButton.Image = ((System.Drawing.Image)(resources.GetObject("recognitionButton.Image")));
            this.recognitionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recognitionButton.Name = "recognitionButton";
            this.recognitionButton.Size = new System.Drawing.Size(123, 22);
            this.recognitionButton.Text = "Распознать объекты";
            this.recognitionButton.Click += new System.EventHandler(this.recognitionButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resumeButton.Image = ((System.Drawing.Image)(resources.GetObject("resumeButton.Image")));
            this.resumeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(53, 22);
            this.resumeButton.Text = "Рестарт";
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(188, 22);
            this.openButton.Text = "Открыть изображение из файла";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // pictureCameraBox
            // 
            this.pictureCameraBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureCameraBox.Location = new System.Drawing.Point(0, 25);
            this.pictureCameraBox.Name = "pictureCameraBox";
            this.pictureCameraBox.Size = new System.Drawing.Size(1280, 720);
            this.pictureCameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCameraBox.TabIndex = 2;
            this.pictureCameraBox.TabStop = false;
            this.pictureCameraBox.DoubleClick += new System.EventHandler(this.pictureCameraBox_DoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG|*.jpg|PNG|*.png|Bitmap|*.bmp";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 745);
            this.Controls.Add(this.pictureCameraBox);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Object Recognition";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCameraBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox camerasStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.PictureBox pictureCameraBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton recognitionButton;
        private System.Windows.Forms.ToolStripButton resumeButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton modeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton repeatButton;
        private System.Windows.Forms.ToolStripButton alarmButton;
    }
}

