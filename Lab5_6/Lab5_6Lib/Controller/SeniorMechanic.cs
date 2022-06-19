using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace лаба5_6_с_шарп.Controller
{
    // Данный класс имеет возможность создавать объект, способный ремонтировать конвеер.
    // При этом, сразу же при начале ремонтных работ конвеер возобнавляет работу
    public class SeniorMechanic : Models.IMechanics
    {
        public Models.Parts SenMechanic = new();
        public int RepairSpeed { get; set; }    // Скорость починки
        public int Progress { get; set; }   // Прогресс починки
        public bool Busyness { get; set; }  // True - свободен, False- занят


        public SeniorMechanic()
        {
            InitializeMechanic();
        }


        public void InitializeMechanic()
        {
            SenMechanic.PosX = 1100;
            SenMechanic.PosY = 280;
            RepairSpeed = 7;
            Progress = 0;
            Busyness = true;
        }


        public void RepairLoader(ref Models.Conveyors conveyorControll)
        {
            SenMechanic.PosX = conveyorControll.Conveyor.PosX + 700;
            SenMechanic.PosY = conveyorControll.Conveyor.PosY;
            if (Progress < Models.Conveyors.Hitbox)
            {
                Progress += RepairSpeed;
            }
            else
            {
                SenMechanic.PosX = 1100;
                SenMechanic.PosY = 280;
                Busyness = true;
                conveyorControll.WorkStatus = true;
                conveyorControll.RepairStatus = false;
                Progress = 0;
            }
        }


        public void ControlRepair(ref Models.Conveyors conveyorControll)
        {
            Busyness = false;
            conveyorControll.RepairStatus = true;
            if (conveyorControll.WorkStatus == false)
            {
                RepairLoader(ref conveyorControll);
            }
        }
    }
}
