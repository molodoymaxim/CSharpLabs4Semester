using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpWindowInput
{
    public class DoubleValidator : IStringValidator
    {
        string errorMessage = "";
        public string ErrorMessage { get => errorMessage; }

        public bool IsValid(string str)
        {
            double res;
            bool isDouble = Double.TryParse(str, out res);
            if (!isDouble)
                errorMessage = "Введено не число";

            return isDouble;
        }
    }
}
