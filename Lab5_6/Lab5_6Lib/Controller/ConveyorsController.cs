using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace лаба5_6_с_шарп.Controller
{
    public class ConveyorsController
    {
        public Models.Conveyors ConveyorControll;
        private Random _breakdown = new();
        private int int_startY { get; set; }

        public ConveyorsController()
        {
            InitializeConveyorsController();
            InitConveyor();
        }

        public ConveyorsController(int startY)
        {
            InitializeConveyorsController(startY);
            InitConveyor(startY);
        }

        private void InitializeConveyorsController()
        {
            ConveyorControll = new Models.Conveyors();
            int_startY = 0;
            ConveyorControll.Load = false;
            ConveyorControll.WorkStatus = true;
            ConveyorControll.RepairStatus = false;
        }

        private void InitializeConveyorsController(int startY)
        {
            ConveyorControll = new Models.Conveyors();
            int_startY = startY;
            ConveyorControll.Load = false;
            ConveyorControll.WorkStatus = true;
            ConveyorControll.RepairStatus = false;
        }


        private void InitConveyor()
        {
            ConveyorControll.Conveyor.PosX = 250;
            ConveyorControll.Conveyor.PosY = 30;
        }


        private void InitConveyor(int startY)
        {
            ConveyorControll.Conveyor.PosX = 250;
            ConveyorControll.Conveyor.PosY = startY;
        }

        // Операция конвеера
        public void ConveyorOperation()
        {
            // Если на конвеере есть свободное место и детали в запасе есть,
            // то двигаем конвеер и добавляем новую деталь,
            // если на конвеере есть место, но есть деталь, которая дошла до конца, то её тоже удаляем
            // такое может случиться, если погрузчик будет занят другим конвеером и не успеет вовремя добавить детали
            // что приведёт к созданию пустых мест между деталями.
            if (ConveyorControll.ConveyorParts.Count < (Models.Conveyors.NumParts) 
                && ConveyorControll.Reserve.Count > 0)
            {
                foreach (var pPart in ConveyorControll.ConveyorParts)
                {
                    pPart.PosX += 3;
                    pPart.PosY = 35 + int_startY;
                }

                if (ConveyorControll.ConveyorParts.Count == 0)
                {
                    ConveyorControll.ConveyorParts.Enqueue(ConveyorControll.Reserve.Pop());
                }
                else if ((ConveyorControll.ConveyorParts.Peek().PosX - 325) % Models.Conveyors.Step == 0)
                {
                    ConveyorControll.ConveyorParts.Enqueue(ConveyorControll.Reserve.Pop());
                }
                if ((ConveyorControll.ConveyorParts.Peek().PosX - 325) >= (Models.Conveyors.Step * 5 - 10))
                {
                    ConveyorControll.ConveyorParts.Dequeue();
                }
            }
            // Если на конвеере нет свободного места,
            // то двигаем конвеер, удаляем готовую деталь и добавляем деталь новую деталь, если есть
            else if (ConveyorControll.ConveyorParts.Count == Models.Conveyors.NumParts)
            {
                foreach (var pPart in ConveyorControll.ConveyorParts)
                {
                    pPart.PosX += 3;
                    pPart.PosY = 35 + int_startY;
                }

                if ((ConveyorControll.ConveyorParts.Peek().PosX - 325) >= (Models.Conveyors.Step * 5 - 10))
                {
                    ConveyorControll.ConveyorParts.Dequeue();
                    if (ConveyorControll.Reserve.Count > 0)
                    {
                        ConveyorControll.ConveyorParts.Enqueue(ConveyorControll.Reserve.Pop());
                    }
                }
            }
            // Если на конвеере есть свободное место, но деталей в запасе нет, а на конвеере ещё есть,
            // то двигаем конвеер и удаляем готовую деталь
            else if (ConveyorControll.ConveyorParts.Count < Models.Conveyors.NumParts
                && ConveyorControll.Reserve.Count == 0 
                && ConveyorControll.ConveyorParts.Count != 0)
            {
                foreach (var pPart in ConveyorControll.ConveyorParts)
                {
                    pPart.PosX += 3;
                    pPart.PosY = 35 + int_startY;
                }

                if ((ConveyorControll.ConveyorParts.Peek().PosX - 325) >= (Models.Conveyors.Step * 5 -10 ))
                {
                    ConveyorControll.ConveyorParts.Dequeue();
                }
            }
        }


        public void ConveyorIsBroken()
        {
            if (_breakdown.NextDouble() >= Models.Conveyors.Reliability)
            {
                ConveyorControll.WorkStatus = false;
            }
        }
    }
}
