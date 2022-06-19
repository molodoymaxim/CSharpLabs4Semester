using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace лаба5_6_с_шарп.Controller
{
    // Данный класс имеет возможность создавать объект, способный ремонтировать конвеер.
    // Более того, если данный объект класса добавлен в модель, то другие существующие механики получают бонус к скорости ремонта.
    public class ChiefEngineer : Models.IMechanics
    {
        public Models.Parts ChiefMechanic = new();
        public int RepairSpeed { get; set; }    // Скорость починки
        public int Progress { get; set; }   // Прогресс починки
        public bool Busyness { get; set; }  // True - свободен, False- занят


        public ChiefEngineer()
        {
            InitializeMechanic();
        }


        public void InitializeMechanic()
        {
            ChiefMechanic.PosX = 1100;
            ChiefMechanic.PosY = 60;
            RepairSpeed = 2;
            Progress = 0;
            Busyness = true;
        }


        public static void ChiefOnField(SeniorMechanic senmech, JuniorMechanic junmech)
        {
            if (senmech != null)
            {
                senmech.RepairSpeed += 10;
            }
            if (junmech != null)
            {
                junmech.RepairSpeed += 17;
            }
        }


        public static void ChiefOffField(SeniorMechanic senmech, JuniorMechanic junmech)
        {
            if (senmech != null)
            {
                senmech.RepairSpeed -= 10;
            }
            if (junmech != null)
            {
                junmech.RepairSpeed -= 17;
            }
        }


        public void RepairLoader(ref Models.Conveyors conveyorControll)
        {
            ChiefMechanic.PosX = conveyorControll.Conveyor.PosX + 700;
            ChiefMechanic.PosY = conveyorControll.Conveyor.PosY;
            if (Progress < Models.Conveyors.Hitbox)
            {
                Progress += RepairSpeed;
            }
            else
            {
                ChiefMechanic.PosX = 1100;
                ChiefMechanic.PosY = 60;
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
