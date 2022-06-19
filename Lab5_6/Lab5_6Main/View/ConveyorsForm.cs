using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


/*
Задача 5. (19)
В зависимости от задачи необходимо смоделировать ситуацию/процесс. В каждой модели есть набор возможных ситуаций. Для некоторых событий необходимо определить 
вероятность возникновения данного события. Интерфейс необходимо реализовать, используя 3 и более классов. Для решения задач необходимо использовать:
Делегаты/события.
Многопоточность
Где необходимо рефлексию
На форме должно быть динамическое изменение моделей – все должно двигаться. Иметь возможность добавлять несколько моделей на форму.

19. Конвейер с деталями – смоделировать работу конвейера производства деталей. Реализовать классы – Конвейер, 
Погрузчик, интерфейс – Механик. События – в конвейере закончились материалы – погрузчик загружает новую партию, 
конвейер сломался (с некоторой долей вероятности) – механик чинит конвейер.

Задача 6.
Доработать предыдущую задачу с использованием синхронизации потоков. На форме должно быть не менее 4 моделей. Ограничения накладываются на классы, 
которые реализуют интерфейсы. Для 4 моделей должно быть 2 объекта данных  классов в сумме. При возникновении какого-то события 1 из объектов «лочится»
и не доступен для использования  в других моделях.
*/
namespace лаба5_6_с_шарп.View
{
    public partial class ConveyorsForm : Form
    {
        private Controller.ConveyorsController[] _conveyorsMashine;
        private Controller.LoaderController[] _loadersMashine;
        private Controller.ChiefEngineer _chiefmech;
        private Controller.SeniorMechanic _senmech;
        private Controller.JuniorMechanic _junmech;

        private Thread[] _thread;
        private bool[] _threadStatus;
        private object _lockerConveyors;
        private object _lockerLoaders;
        private object _lockerMechanic;
        private int int_busyThread { get; set; }
        private int[] _loaderMechanic;
        private int int_countMechanic { get; set; }

        private Graphics[] _graphicsConveyors;
        private Graphics[] _graphicsParts;
        private Graphics[] _graphicsLoaders;
        private Graphics _graphicsMechanic;
        private PictureBox[] _disableMichanics;
        private Label[] _nameMechanics;
        private Label[] _parametersMechanics;

        private Button[] _buttonModelCreate;
        private Button[] _buttonModelDestroy;
        private Button[] _buttonMechanicCreate;
        private Button[] _buttonMechanicDestroy;
        private Button _buttonInfo;
        private Button _buttonTask;

        private Bitmap _conveyorImage;
        private Bitmap _loaderImage;
        private Bitmap _clearLoaderImage;
        private Bitmap _partsImage;
        private Bitmap _clearPartsImage;
        private Bitmap _fireImage;
        private Bitmap _chiefmechImage;
        private Bitmap _senmechImage;
        private Bitmap _junmechImage;
        private Bitmap _clearMechImage;

        // Инициализируем необходимые для модели данные
        private void InitializeModels()
        {
            _conveyorsMashine = new Controller.ConveyorsController[Program.ThreadNumber];
            _loadersMashine = new Controller.LoaderController[Program.ThreadNumber];

            _thread = new Thread[Program.ThreadNumber];
            _threadStatus = new bool[Program.ThreadNumber];
            _lockerConveyors = new object();
            _lockerLoaders = new object();
            _lockerMechanic = new object();
            int_busyThread = -1;
            _loaderMechanic = new int[3];
            int_countMechanic = 0;

            _graphicsConveyors = new Graphics[Program.ThreadNumber];
            _graphicsParts = new Graphics[Program.ThreadNumber];
            _graphicsLoaders = new Graphics[Program.ThreadNumber];
            _graphicsMechanic = CreateGraphics();
            _disableMichanics = new PictureBox[3];
            _nameMechanics = new Label[3];
            _parametersMechanics = new Label[3];

            _buttonModelCreate = new Button[Program.ThreadNumber];
            _buttonModelDestroy = new Button[Program.ThreadNumber];
            _buttonMechanicCreate = new Button[3];
            _buttonMechanicDestroy = new Button[3];
            _buttonInfo = new Button();
            _buttonTask = new Button();
        }

        // Инициализируем исходные изображения
        private void InitializeImage()
        {
            // C:\Users\username\Desktop\Лаба по cAhRP\LabsCSharp\лаба5_6_с_шарп\Resources\
            _conveyorImage = new Bitmap(@"../../../Resources/conveyor.png");
            _loaderImage = new Bitmap(@"../../../Resources/loader.png");
            _clearLoaderImage = new Bitmap(@"../../../Resources/clearloader.png");
            _partsImage = new Bitmap(@"../../../Resources/part.png");
            _clearPartsImage = new Bitmap(@"../../../Resources/clearpart.png");
            _fireImage = new Bitmap(@"../../../Resources/fire.png");
            _chiefmechImage = new Bitmap(@"../../../Resources/chiefengineerdisable.png");
            _senmechImage = new Bitmap(@"../../../Resources/seniormechanicdisable.png");
            _junmechImage = new Bitmap(@"../../../Resources/juniormechanicdisable.png");
            _clearMechImage = new Bitmap(@"../../../Resources/clearmechanic.png");
        }


        public ConveyorsForm()
        {
            InitializeComponent();
            this.FormClosed += ConveyorsForm_Close;
        }


        private void ConveyorsForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1280, 720);
            InitializeModels();
            InitializeImage();
            InitializeButton();
            InitializeImageMechanic();
            InitializeAdditionalButton();
        }

        // Останавливаем потоки при закрытии формы
        private void ConveyorsForm_Close(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_chiefmech != null)
                {
                    _chiefmech.Busyness = true;
                }
                if (_senmech != null)
                {
                    _senmech.Busyness = true;
                }
                if (_junmech != null)
                {
                    _junmech.Busyness = true;
                }
                DestructMechanic(i);
            }
            for (int i = 0; i < Program.ThreadNumber; i++)
            {
                DestructConveyor(i);
            }
        }

        // Инициализируем и запускаем потоки
        private void InitializeThread(int numThread)
        {
            // При инициализации потока указываем делегат, передающий объект в поток
            _thread[numThread] = new Thread((obj) => StartConveyors(obj));

            _thread[numThread].Start(numThread);
        }

        // При нажатии кнопки, удаляющей конвеер, получаем сигнал - F_threadStatus = false,
        // который приводит к завершению потока. Далее ожидаем завершение потока и обнуляем выбранный конвеер
        private void DestructConveyor(int numThread)
        {
            if (_thread[numThread] != null)
            {
                СancelMechanic(numThread);
                _threadStatus[numThread] = false;

                if (_thread[numThread].Join(2000) == true)
                {
                    _graphicsParts[numThread] = null;
                    _graphicsLoaders[numThread] = null;
                    _graphicsConveyors[numThread] = null;
                    _loadersMashine[numThread] = null;
                    _conveyorsMashine[numThread] = null;
                }
            }
        }

        delegate void ConveyorDelegate(object obj);
        // Запускаем конвеер
        private void StartConveyors(object obj)
        {
            // Инициализируем данные для нового конвеера
            int numThread = (int)obj;
            _threadStatus[numThread] = true;
            _conveyorsMashine[numThread] = new Controller.ConveyorsController(160 * numThread + 30);
            _loadersMashine[numThread] = new Controller.LoaderController(160 * numThread + 30);
            _graphicsConveyors[numThread] = CreateGraphics();
            _graphicsLoaders[numThread] = CreateGraphics();
            _graphicsParts[numThread] = CreateGraphics();
            PaintConveyor(numThread);

            // Вешаем таймер на погрузчик внутри потока (Чтобы обращаться к данным, инициализированным конкретно в этом потоке.
            // Если бы повесили таймер вне потока, пришлось бы ассинхронно обращаться к данным, например через invoke.
            TimerCallback tmLoad = new(LoadTick);
            System.Threading.Timer timerLoad = new(tmLoad, numThread, 0, 700);

            // Вешаем таймер на механиков
            TimerCallback tmMechanic = new(MechanicTick);
            System.Threading.Timer timerMechanic = new(tmMechanic, null, 0, 1000);

            // Вешаем таймер на сам конвеер
            TimerCallback tmConveyors = new(ConveyorsTick);
            System.Threading.Timer timerConveyors = new(tmConveyors, numThread, 0, 100);
            // p.s. TimerCallback представляет собой делегат =)

            // Бесконечный цикл, пока не заврешится поток принудительно, или не будет получен сигнал с кнопки удаления конвеера
            while (_thread[numThread].IsAlive && _threadStatus[numThread] == true) { }
            AutoResetEvent waitHandlerLoad = new(false);
            AutoResetEvent waitHandlerConveyors = new(false);
            timerLoad.Dispose(waitHandlerLoad);
            timerConveyors.Dispose(waitHandlerConveyors);
            waitHandlerLoad.WaitOne();
            // Останавливаем все таймеры и дожидаемся их остановки, что бы не отчистить данные конвеера, во время тика таймера
            waitHandlerConveyors.WaitOne();
        }

        // Действие погрузчика
        private void LoadTick(object obj)
        {
            int numThread = (int)obj;

            // Если загрзчик занят определённым конвеером(по индексу потока), и именно
            // для этого конвеера вызван этот метод или погрузщик не занят не занят(-1), то
            if (numThread == int_busyThread || int_busyThread == -1)
            {
                // Закрепляем погрузчик за конвеером
                int_busyThread = numThread;
                // Грузим детали
                _loadersMashine[numThread].ControlLoad(_conveyorsMashine[numThread].ConveyorControll);
                // Отрисовываем погрузчик рядом с нужным конвеером
                PaintLoader(numThread);
                bool checkBusy = true;
                foreach (var LoadMashine in _loadersMashine)
                {
                    if (LoadMashine != null)
                    {
                        checkBusy = checkBusy && !LoadMashine.LoaderControll.Loading;
                    }
                }
                // Если погрузчик закончил погрузку, освобожаем для других конвееров
                if (checkBusy == true)
                {
                    int_busyThread = -1;
                }
            }
        }

        // Действие конвеера
        private void ConveyorsTick(object obj)
        {
            int numThread = (int)obj;

            lock (_lockerConveyors)
            {
                if (_conveyorsMashine[numThread].ConveyorControll.WorkStatus)
                {
                    // Передвигаем детальки
                    _conveyorsMashine[numThread].ConveyorOperation();
                    // Проверяем на исправность
                    _conveyorsMashine[numThread].ConveyorIsBroken();
                    // Отрисовываем детали по обновлённым данным
                    PaintParts(numThread);
                }
            }
        }

        // Рисуем детальки
        private void PaintParts(int numThread)
        {
            if (_conveyorsMashine[numThread].ConveyorControll.WorkStatus == true)
            {
                // Отчищает детали со старыми координатами
                _graphicsParts[numThread].DrawImage(_clearPartsImage, 250, 160 * numThread + 30);
            }
            else
            {
                // Отрисовывает поломку конвеера
                _graphicsParts[numThread].DrawImage(_fireImage, 250, 160 * numThread + 30);
            }
            if (_conveyorsMashine[numThread].ConveyorControll.ConveyorParts.Count != 0)
            {
                foreach (var part in _conveyorsMashine[numThread].ConveyorControll.ConveyorParts)
                {
                    _graphicsParts[numThread].DrawImage(_partsImage, part.PosX, part.PosY);
                }
            }
        }

        // Рисуем конвеер
        private void PaintConveyor(int numThread)
        {
            _graphicsConveyors[numThread].DrawImage(_conveyorImage,
                _conveyorsMashine[numThread].ConveyorControll.Conveyor.PosX,
                _conveyorsMashine[numThread].ConveyorControll.Conveyor.PosY);
        }

        // Рисуем загрузчик
        private void PaintLoader(int numThread)
        {
            lock (_lockerLoaders)
            {

                _graphicsLoaders[numThread].DrawImage(_clearLoaderImage, 0, 0);
                _graphicsLoaders[numThread].DrawImage(_loaderImage,
                    _loadersMashine[numThread].LoaderControll.Loader.PosX,
                    _loadersMashine[numThread].LoaderControll.Loader.PosY);
            }
        }

        // Инициализируем механиков
        private void InitializeMechanic(int number)
        {
            switch (number)
            {
                case 0:
                    _chiefmech = new Controller.ChiefEngineer();
                    Controller.ChiefEngineer.ChiefOnField(_senmech, _junmech);
                    _chiefmechImage = new Bitmap(@"../../../Resources/chiefengineer.png");
                    _parametersMechanics[0].Text = "Repair speed = " + _chiefmech.RepairSpeed.ToString();
                    if (_senmech != null)
                    {
                        _parametersMechanics[1].Text = "Repair speed = " + _senmech.RepairSpeed.ToString();
                    }
                    if (_junmech != null)
                    {
                        _parametersMechanics[2].Text = "Repair speed = " + _junmech.RepairSpeed.ToString();
                    }
                    break;
                case 1:
                    _senmech = new Controller.SeniorMechanic();
                    if (_chiefmech != null)
                    {
                        Controller.ChiefEngineer.ChiefOnField(_senmech, null);
                    }
                    _senmechImage = new Bitmap(@"../../../Resources/seniormechanic.png");
                    _parametersMechanics[1].Text = "Repair speed = " + _senmech.RepairSpeed.ToString();
                    break;
                case 2:
                    _junmech = new Controller.JuniorMechanic();
                    if (_chiefmech != null)
                    {
                        Controller.ChiefEngineer.ChiefOnField(null, _junmech);
                    }
                    _junmechImage = new Bitmap(@"../../../Resources/juniormechanic.png");
                    _parametersMechanics[2].Text = "Repair speed = " + _junmech.RepairSpeed.ToString();
                    break;
            }
        }

        // Обнуляем механиков
        private void DestructMechanic(int number)
        {
            switch (number)
            {
                case 0:
                    if (_chiefmech != null)
                    {
                        while (!_chiefmech.Busyness) { }
                        Controller.ChiefEngineer.ChiefOffField(_senmech, _junmech);
                        _chiefmech = null;
                        _chiefmechImage = new Bitmap(@"../../../Resources/chiefengineerdisable.png");
                        if (_senmech != null)
                        {
                            _parametersMechanics[1].Text = "Repair speed = " + _senmech.RepairSpeed.ToString();
                        }
                        if (_junmech != null)
                        {
                            _parametersMechanics[2].Text = "Repair speed = " + _junmech.RepairSpeed.ToString();
                        }
                    }
                    break;
                case 1:
                    if (_senmech != null)
                    {
                        while (!_senmech.Busyness) { }
                        if (_chiefmech != null)
                        {
                            Controller.ChiefEngineer.ChiefOffField(_senmech, null);
                        }
                        _senmech = null;
                        _senmechImage = new Bitmap(@"../../../Resources/seniormechanicdisable.png");
                    }
                    break;
                case 2:
                    if (_junmech != null)
                    {
                        while (!_junmech.Busyness) { }
                        if (_chiefmech != null)
                        {
                            Controller.ChiefEngineer.ChiefOffField(null, _junmech);
                        }
                        _junmech = null;
                        _junmechImage = new Bitmap(@"../../../Resources/juniormechanicdisable.png");
                    }
                    break;
            }
        }

        // Действие механиков
        private void MechanicTick(object sender)
        {
            // Ищет свободного механика и занимаем его за нужным конвеером
            MechanicSearch();
            if (_chiefmech != null)
            {
                // Если механик занят, то продолжаем чинить, как починит, сменит статус на свободного
                if (!_chiefmech.Busyness)
                {
                    _chiefmech.ControlRepair(ref _conveyorsMashine[_loaderMechanic[0]].ConveyorControll);
                }
            }
            if (_senmech != null)
            {
                if (!_senmech.Busyness)
                {
                    _senmech.ControlRepair(ref _conveyorsMashine[_loaderMechanic[1]].ConveyorControll);
                }
            }
            if (_junmech != null)
            {
                if (!_junmech.Busyness)
                {
                    _junmech.ControlRepair(ref _conveyorsMashine[_loaderMechanic[2]].ConveyorControll);
                }
            }
            PaintMechanic();
        }

        // Поиск свободных механиков
        private void MechanicSearch()
        {
            bool findMechanic = false;
            for (int i = 0; i < Program.ThreadNumber; i++)
            {
                if (_conveyorsMashine[i] != null)
                {
                    if (!_conveyorsMashine[i].ConveyorControll.WorkStatus
                        && !_conveyorsMashine[i].ConveyorControll.RepairStatus)
                    {
                        if (_junmech != null && findMechanic == false)
                        {
                            if (_junmech.Busyness)
                            {
                                // есди свободен, помечаем что нашли, чтоб выйти из условия,
                                // помечаем, что механик занаят, и запомниаем, какой конвеер он ремонтирует
                                findMechanic = true;
                                _junmech.Busyness = false;
                                _loaderMechanic[2] = i;
                            }
                        }
                        if (_senmech != null && findMechanic == false)
                        {
                            if (_senmech.Busyness)
                            {
                                findMechanic = true;
                                _senmech.Busyness = false;
                                _loaderMechanic[1] = i;
                            }
                        }
                        if (_chiefmech != null && findMechanic == false)
                        {
                            if (_chiefmech.Busyness)
                            {
                                findMechanic = true;
                                _chiefmech.Busyness = false;
                                _loaderMechanic[0] = i;
                            }
                        }
                    }
                }
            }
        }

        // Отрисовываем механиков
        private void PaintMechanic()
        {
            lock (_lockerMechanic)
            {
                _graphicsMechanic.DrawImage(_clearMechImage, 950, 0);
                if (_chiefmech != null)
                {
                    _graphicsMechanic.DrawImage(_chiefmechImage, _chiefmech.ChiefMechanic.PosX, _chiefmech.ChiefMechanic.PosY);
                }
                if (_senmech != null)
                {
                    _graphicsMechanic.DrawImage(_senmechImage, _senmech.SenMechanic.PosX, _senmech.SenMechanic.PosY);
                }
                if (_junmech != null)
                {
                    _graphicsMechanic.DrawImage(_junmechImage, _junmech.JunMechanic.PosX, _junmech.JunMechanic.PosY);
                }
            }
        }

        // Отменяем действие механика при уничтожении ковеера
        private void СancelMechanic (int numThread)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_loaderMechanic[i] == numThread)
                {
                    switch (i)
                    {
                        case 0:
                            if (_chiefmech != null)
                            {
                                _chiefmech.Busyness = true;
                                _chiefmech.ChiefMechanic.PosX = 1100;
                                _chiefmech.ChiefMechanic.PosY = 60;
                            }
                            break;
                        case 1:
                            if (_senmech != null)
                            {
                                _senmech.Busyness = true;
                                _senmech.SenMechanic.PosX = 1100;
                                _senmech.SenMechanic.PosY = 280;
                            }
                            break;
                        case 2:
                            if (_junmech != null)
                            {
                                _junmech.Busyness = true;
                                _junmech.JunMechanic.PosX = 1100;
                                _junmech.JunMechanic.PosY = 500;
                            }
                            break;
                    }
                }
            }
        }

        #region Button Form Code
        // Здесь содержатся все доступные кнопки программы.
        private void InitializeButton()
        {
            InitializeButtonCreateModel();
            InitializeButtonDestroyModel();
            InitializeButtonCreateMechanic();
            InitializeButtonDestroyMechanic();
        }


        private void InitializeButtonCreateModel()
        {
            for (int i = 0; i < _buttonModelCreate.Length; i++)
            {
                _buttonModelCreate[i] = new Button();
                _buttonModelCreate[i].Enabled = true;
                _buttonModelCreate[i].Visible = true;
                _buttonModelCreate[i].Size = new Size(700, 150);
                _buttonModelCreate[i].Location = new Point(250, 160 * i + 30);
                _buttonModelCreate[i].Text = "Press button to create new model of conveyor";
                _buttonModelCreate[i].Font = new Font("Arial", 24, FontStyle.Bold);
                this.Controls.Add(_buttonModelCreate[i]);
            }
            _buttonModelCreate[0].Click += ButtonModelCreateOne_Click;
            _buttonModelCreate[1].Click += ButtonModelCreateTwo_Click;
            _buttonModelCreate[2].Click += ButtonModelCreateThree_Click;
            _buttonModelCreate[3].Click += ButtonModelCreateFour_Click;
        }


        private void InitializeButtonDestroyModel()
        {
            for (int i = 0; i < _buttonModelDestroy.Length; i++)
            {
                _buttonModelDestroy[i] = new Button();
                _buttonModelDestroy[i].Enabled = true;
                _buttonModelDestroy[i].Visible = false;
                _buttonModelDestroy[i].Size = new Size(700, 25);
                _buttonModelDestroy[i].Location = new Point(250, 160 * (i + 1) + 5);
                _buttonModelDestroy[i].Text = "Press button to destroy model of conveyor";
                _buttonModelDestroy[i].Font = new Font("Arial", 12, FontStyle.Bold);
                this.Controls.Add(_buttonModelDestroy[i]);
            }
            _buttonModelDestroy[0].Click += ButtonModelDestroyOne_Click;
            _buttonModelDestroy[1].Click += ButtonModelDestroyTwo_Click;
            _buttonModelDestroy[2].Click += ButtonModelDestroyThree_Click;
            _buttonModelDestroy[3].Click += ButtonModelDestroyFour_Click;
        }


        private void InitializeButtonCreateMechanic()
        {
            for (int i = 0; i < _buttonMechanicCreate.Length; i++)
            {
                _buttonMechanicCreate[i] = new Button();
                _buttonMechanicCreate[i].Enabled = true;
                _buttonMechanicCreate[i].Visible = true;
                _buttonMechanicCreate[i].Size = new Size(80, 25);
                _buttonMechanicCreate[i].Location = new Point(1090, 220 * (i + 1) - 25);
                _buttonMechanicCreate[i].Text = "Recruit";
                _buttonMechanicCreate[i].Font = new Font("Arial", 12, FontStyle.Bold);
                this.Controls.Add(_buttonMechanicCreate[i]);
            }
            _buttonMechanicCreate[0].Click += ButtonMechanicCreateOne_Click;
            _buttonMechanicCreate[1].Click += ButtonMechanicCreateTwo_Click;
            _buttonMechanicCreate[2].Click += ButtonMechanicCreateThree_Click;
        }


        private void InitializeButtonDestroyMechanic()
        {
            for (int i = 0; i < _buttonMechanicDestroy.Length; i++)
            {
                _buttonMechanicDestroy[i] = new Button();
                _buttonMechanicDestroy[i].Enabled = false;
                _buttonMechanicDestroy[i].Visible = true;
                _buttonMechanicDestroy[i].Size = new Size(80, 25);
                _buttonMechanicDestroy[i].Location = new Point(1170, 220 * (i + 1) - 25);
                _buttonMechanicDestroy[i].Text = "Dismiss";
                _buttonMechanicDestroy[i].Font = new Font("Arial", 12, FontStyle.Bold);
                this.Controls.Add(_buttonMechanicDestroy[i]);
            }
            _buttonMechanicDestroy[0].Click += ButtonMechanicDestroyOne_Click;
            _buttonMechanicDestroy[1].Click += ButtonMechanicDestroyTwo_Click;
            _buttonMechanicDestroy[2].Click += ButtonMechanicDestroyThree_Click;
        }


        private void InitializeImageMechanic()
        {
            for (int i = 0; i < _disableMichanics.Length; i++)
            {
                _disableMichanics[i] = new PictureBox();
                _disableMichanics[i].Visible = true;
                _disableMichanics[i].Size = new Size(114, 134);
                _disableMichanics[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(_disableMichanics[i]);
                _nameMechanics[i] = new Label();
                _nameMechanics[i].Visible = true;
                _nameMechanics[i].Size = new Size(170, 20);
                _nameMechanics[i].Font = new Font("Arial", 13, FontStyle.Bold);
                this.Controls.Add(_nameMechanics[i]);
                _parametersMechanics[i] = new Label();
                _parametersMechanics[i].Visible = false;
                _parametersMechanics[i].Size = new Size(170, 20);
                _parametersMechanics[i].Font = new Font("Arial", 11, FontStyle.Regular);
                this.Controls.Add(_parametersMechanics[i]);
            }
            _disableMichanics[0].Image = new Bitmap(@"../../../Resources/chiefengineerdisable.png");
            _nameMechanics[0].Text = "Chief Engineer";
            _disableMichanics[0].Location = new Point(1100, 60);
            _nameMechanics[0].Location = new Point(1100, 20);
            _parametersMechanics[0].Location = new Point(1100, 40);
            _disableMichanics[1].Image = new Bitmap(@"../../../Resources/seniormechanicdisable.png");
            _nameMechanics[1].Text = "Senior Mechanic";
            _disableMichanics[1].Location = new Point(1100, 280);
            _nameMechanics[1].Location = new Point(1100, 240);
            _parametersMechanics[1].Location = new Point(1100, 260);
            _disableMichanics[2].Image = new Bitmap(@"../../../Resources/juniormechanicdisable.png");
            _nameMechanics[2].Text = "Junior Mechanic";
            _disableMichanics[2].Location = new Point(1100, 500);
            _nameMechanics[2].Location = new Point(1100, 460);
            _parametersMechanics[2].Location = new Point(1100, 480);
        }


        private void InitializeAdditionalButton()
        {
            _buttonInfo.Enabled = true;
            _buttonInfo.Visible = true;
            _buttonInfo.Size = new Size(60, 30);
            _buttonInfo.Location = new Point(0, 0);
            _buttonInfo.Text = "Info";
            _buttonInfo.Font = new Font("Arial", 12, FontStyle.Regular);
            _buttonInfo.Click += ButtonInfo_Click;
            this.Controls.Add(_buttonInfo);

            _buttonTask.Enabled = true;
            _buttonTask.Visible = true;
            _buttonTask.Size = new Size(60, 30);
            _buttonTask.Location = new Point(60, 0);
            _buttonTask.Text = "Task";
            _buttonTask.Font = new Font("Arial", 12, FontStyle.Regular);
            _buttonTask.Click += ButtonTask_Click;
            this.Controls.Add(_buttonTask);
        }

        // Кнопки для создания новой модели конвеера
        private void ButtonModelCreateOne_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[0].Visible = false;
            _buttonModelDestroy[0].Visible = true;
            InitializeThread(0);
        }


        private void ButtonModelCreateTwo_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[1].Visible = false;
            _buttonModelDestroy[1].Visible = true;
            InitializeThread(1);
        }


        private void ButtonModelCreateThree_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[2].Visible = false;
            _buttonModelDestroy[2].Visible = true;
            InitializeThread(2);
        }


        private void ButtonModelCreateFour_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[3].Visible = false;
            _buttonModelDestroy[3].Visible = true;
            InitializeThread(3);
        }

        // Кнопки для уничтожения новой модели конвеера
        private void ButtonModelDestroyOne_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[0].Visible = true;
            _buttonModelDestroy[0].Visible = false;
            DestructConveyor(0);
        }


        private void ButtonModelDestroyTwo_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[1].Visible = true;
            _buttonModelDestroy[1].Visible = false;
            DestructConveyor(1);
        }


        private void ButtonModelDestroyThree_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[2].Visible = true;
            _buttonModelDestroy[2].Visible = false;
            DestructConveyor(2);
        }


        private void ButtonModelDestroyFour_Click(object sender, EventArgs e)
        {
            _buttonModelCreate[3].Visible = true;
            _buttonModelDestroy[3].Visible = false;
            DestructConveyor(3);
        }

        // Кнопки для найма механика
        private void ButtonMechanicCreateOne_Click(object sender, EventArgs e)
        {
            if (int_countMechanic < 2)
            {
                ++int_countMechanic;
                _disableMichanics[0].Visible = false;
                _parametersMechanics[0].Visible = true;
                _buttonMechanicCreate[0].Enabled = false;
                _buttonMechanicDestroy[0].Enabled = true;
                InitializeMechanic(0);
                PaintMechanic();
            }
            else
            {
                MessageNoMoreTwo();
            }
        }


        private void ButtonMechanicCreateTwo_Click(object sender, EventArgs e)
        {
            if (int_countMechanic < 2)
            {
                ++int_countMechanic;
                _disableMichanics[1].Visible = false;
                _parametersMechanics[1].Visible = true;
                _buttonMechanicCreate[1].Enabled = false;
                _buttonMechanicDestroy[1].Enabled = true;
                InitializeMechanic(1);
                PaintMechanic();
            }
            else
            {
                MessageNoMoreTwo();
            }
        }


        private void ButtonMechanicCreateThree_Click(object sender, EventArgs e)
        {
            if (int_countMechanic < 2)
            {
                ++int_countMechanic;
                _disableMichanics[2].Visible = false;
                _parametersMechanics[2].Visible = true;
                _buttonMechanicCreate[2].Enabled = false;
                _buttonMechanicDestroy[2].Enabled = true;
                InitializeMechanic(2);
                PaintMechanic();
            }
            else
            {
                MessageNoMoreTwo();
            }
        }

        // Кнопки для увольнение механика
        private void ButtonMechanicDestroyOne_Click(object sender, EventArgs e)
        {
            --int_countMechanic;
            _disableMichanics[0].Visible = true;
            _parametersMechanics[0].Visible = false;
            _buttonMechanicCreate[0].Enabled = true;
            _buttonMechanicDestroy[0].Enabled = false;
            DestructMechanic(0);
            PaintMechanic();
        }


        private void ButtonMechanicDestroyTwo_Click(object sender, EventArgs e)
        {
            --int_countMechanic;
            _disableMichanics[1].Visible = true;
            _parametersMechanics[1].Visible = false;
            _buttonMechanicCreate[1].Enabled = true;
            _buttonMechanicDestroy[1].Enabled = false;
            DestructMechanic(1);
            PaintMechanic();
        }


        private void ButtonMechanicDestroyThree_Click(object sender, EventArgs e)
        {
            --int_countMechanic;
            _disableMichanics[2].Visible = true;
            _parametersMechanics[2].Visible = false;
            _buttonMechanicCreate[2].Enabled = true;
            _buttonMechanicDestroy[2].Enabled = false;
            DestructMechanic(2);
            PaintMechanic();
        }


        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            MessageProgramInformation();
        }


        private void ButtonTask_Click(object sender, EventArgs e)
        {
            MessageTaskInformation();
        }


        private static void MessageNoMoreTwo()
        {
            MessageBox.Show(
                "Максимальное колличество механиков в модели не более двух. " +
                "Удалите одного из существующих механиков, чтобы нанять нового.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
        }


        private static void MessageProgramInformation()
        {
            MessageBox.Show(
                "Данная программа моделирует процесс конвеера.\n" +
                "Погрузчик загружает товары на конвеер, а конвеерная линия двигает их.\n" +
                "Конвеер с некоторой вероятностью может сломаться. Для востановления конвеера" +
                "механик должен восстановить 100 единиц прочности конвеера.\n" +
                "Доступно на выбор три механика, наследуемых от одного интерфейса.\n" +
                "\nПервый механик - Chief Engineer имеет самую низкую скорость починки в 2 единицы в секунду," +
                "однако даёт бонус к скорости починки конвеера другим механикам." +
                "+10 единиц для SeniorMechanic и +17 единиц для JuniorMechanic.\n" +
                "\nВторой механик - SeniorMechanic имеет скорость ремонта 7 единиц в секунду.\n" +
                "\nТретий механик - JuniorMechanic имеет скорость ремонта 3 единицы в секунду.\n" +
                "\nНа форме можно разместить четыре модели конвеера. Под работу каждого конвеера" +
                "создаётся собственный поток. Таким образом четыре конвеера будут выполняться в четырёх разных потоках.",
                "Информация о программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }


        private static void  MessageTaskInformation()
        {
            MessageBox.Show(
                "Зачание №5, 6. Вариант №19.\n" +
                "\n№5. В зависимости от задачи необходимо смоделировать ситуацию/процесс.\n" +
                "В каждой модели есть набор возможных ситуаций.\n" +
                "Для некоторых событий необходимо определить вероятность возникновения данного события.\n" +
                "Интерфейс необходимо реализовать, используя 3 и более классов.\n" +
                "\nДля решения задач необходимо использовать:\n" +
                "\n1. Делегаты / события.\n" +
                "2. Многопоточность\n" +
                "3. Где необходимо рефлексию\n" +
                "\nНа форме должно быть динамическое изменение моделей – все должно двигаться.\n" +
                "Иметь возможность добавлять несколько моделей на форму.\n" +
                "\n19. Конвейер с деталями – смоделировать работу конвейера производства деталей.\n" +
                "Реализовать классы – Конвейер, Погрузчик, интерфейс – Механик.\n" +
                "События – в конвейере закончились материалы – погрузчик загружает новую партию,\n" +
                "конвейер сломался (с некоторой долей вероятности) – механик чинит конвейер.\n" +
                "\n№6. Доработать предыдущую задачу с использованием синхронизации потоков. " +
                "На форме должно быть не менее 4 моделей. " +
                "Ограничения накладываются на классы, которые реализуют интерфейсы. " +
                "Для 4 моделей должно быть 2 объекта данных  классов в сумме. " +
                "При возникновении какого-то события 1 из объектов «лочится» " +
                "и не доступен для использования в других моделях.",
                "Условие задачи",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }
        #endregion
    }
}
