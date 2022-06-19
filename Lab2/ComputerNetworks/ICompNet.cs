using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerNetworks
{
    public interface ICompNetPrint
    {
        void PrintNameCorp(string nameCorp_);
        void PrintNumEmployee(int numEmployee_);
        void PrintDistance(double distance_);
        void PrintQuality(double quality_);
        void PrintTransferRate(double transferRate_);
    }

    public interface ICompNetInp
    {
        string InputNameCorp();
        int InputNumEmployee();
        double InputDistance();
        double InputTransferRate();
    }
}
