using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace лаба5_6_с_шарп.Models
{
    interface IMechanics
    {
        void InitializeMechanic();

        void RepairLoader(ref Conveyors conveyorControll);

        void ControlRepair(ref Conveyors conveyorControll);
    }
}
