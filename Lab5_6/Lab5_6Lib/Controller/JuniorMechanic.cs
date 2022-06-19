using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace лаба5_6_с_шарп.Controller
{
    // Данный класс имеет возможность создавать объект, способный ремонтировать конвеер.
    // При ремонте, конвеер не деспособен до починки
    public class JuniorMechanic : Models.IMechanics
    {
        public Models.Parts JunMechanic = new();
        public int RepairSpeed { get; set; }    // Скорость починки
        public int Progress { get; set; }   // Прогресс починки
        public bool Busyness { get; set; }  // True - свободен, False- занят


        public JuniorMechanic()
        {
            InitializeMechanic();
        }


        public void InitializeMechanic()
        {
            JunMechanic.PosX = 1100;
            JunMechanic.PosY = 500;
            RepairSpeed = 3;
            Progress = 0;
            Busyness = true;
        }


        public void RepairLoader(ref Models.Conveyors conveyorControll)
        {
            JunMechanic.PosX = conveyorControll.Conveyor.PosX + 700;
            JunMechanic.PosY = conveyorControll.Conveyor.PosY;

            if (Progress < Models.Conveyors.Hitbox)
            {
                Progress += RepairSpeed;
            }
            else
            {
                JunMechanic.PosX = 1100;
                JunMechanic.PosY = 500;
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
