### Распознавание объектов на изображении с помощью библиотеки YoloV3 + детектор движения

- Приложение включает в себя возможность вывести поток видео с веб-камеры на экран, взять отдельный кадр и распознать, какие объекты находятся на изображении
- Технология распознавания объектов реализована с помощью библиотеки YoloV3
- Технология распознавания движения реализована с помощью библиотеки AForge

![](https://media.giphy.com/media/W4N5hD0LpZZkdVlQW9/giphy.gif)

### Дополнительные возможности

- Так же операцию распознавания можно произвести над изображением 

![](https://media.giphy.com/media/YG5OvF4rSqJn1Bpb7L/giphy.gif)

- Присутствует функция распознавания движения. Для её включения необходимо нажать кнопку "Отслеживать движение". Иникатором включения служит цвет кнопки. Теперь на потоковом видео с веб-камеры движущиеся области будут выделяться красным цветом.

![](https://media.giphy.com/media/5oWhZfyrZtr4p8m55k/giphy.gif)

- При нажатии кнопки "Уведомлять о движении с камеры" приложение будет отправлять письмо с предупреждением на почту (email указывается в коде: Form1.cs строка 165), прикрепив к письму кадр текущего момента.

# Для установки
+ Скачайте исходный код, разархивируйте и откройте каталог проекта
+ Создайте каталог "yolo-weights", загрузите и добавьте в него 3 файла: 
	+ [yolov3.weights](https://pjreddie.com/media/files/yolov3.weights)
	+ [yolov3.cfg](https://raw.githubusercontent.com/pjreddie/darknet/master/cfg/yolov3.cfg)
	+ [coco.names](https://raw.githubusercontent.com/pjreddie/darknet/master/data/coco.names)
+ Откройте WebCamObjectRecognition.sln проекта и выполните сборку (Ctrl + Shift + B)
+ Готово. Можно запускать проект с используемой среды, либо с помощью .exe файла, который будет располагаться в папке \bin\x64\Debug

P.S. Проект разрабатывался как ознакомительный: для изучения библиотек YoloV3 и AForge, и не претендует на аккуратность кода, архитектуры, контроль использования памяти и идеальную работоспособность.

### Удачи в использовании!
