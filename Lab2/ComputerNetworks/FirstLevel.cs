using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerNetworks
{
    public class FirstLevel
    {
        public string NameCorp { get; set; }
        public int NumEmloyee { get; set; }
        public double Distance { get; set; }

        public FirstLevel()
        {
            NameCorp ="";
            NumEmloyee = 0;
            Distance = 0;
        }

        public FirstLevel(string nameCorp_, int numEmployee_, double distance_)
        {
            NameCorp = nameCorp_;
            NumEmloyee = numEmployee_;
            Distance = distance_;
        }

        public virtual double Quality()
        {
            return NumEmloyee*Distance;
        }

        public virtual void Print(ICompNetPrint printer)
        {
            printer.PrintNameCorp(NameCorp);
            printer.PrintNumEmployee(NumEmloyee);
            printer.PrintDistance(Distance);

            if (NumEmloyee == 0 || Distance == 0)
                throw new InvalidOperationException("Error! No full strings full!");

            printer.PrintQuality(Quality());
        }

        public virtual void Input(ICompNetInp inpter)
        {
            NameCorp=inpter.InputNameCorp();
            NumEmloyee=inpter.InputNumEmployee();
            Distance=inpter.InputDistance();
        }
    }
}
