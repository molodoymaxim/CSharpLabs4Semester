using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerNetworks
{
    public class SecondLevel : FirstLevel
    {
        public double transferRate { get; set; }

        public SecondLevel()
        {
            transferRate = 0.0;
        }

        public SecondLevel(string nameCorp_, int numEmployee_, int distance_, double transferRate_) :
            base(nameCorp_, numEmployee_, distance_)
        {
            transferRate = transferRate_;
        }

        public override double Quality()
        {
            return (base.Quality() * transferRate);
        }

        public override void Print(ICompNetPrint printer)
        {
            base.Print(printer);
            printer.PrintTransferRate(transferRate);
        }

        public override void Input(ICompNetInp inpter)
        {
            base.Input(inpter);
            transferRate=inpter.InputTransferRate();
        }
    }
}
