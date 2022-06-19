using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpWindowInput
{
    public class NotNegativeDoubleValidator : IStringValidator
    {
        DoubleValidator doubleValid = new DoubleValidator();

        string errorMessage;
        public string ErrorMessage { get => errorMessage; }

        public bool IsValid(string str)
        {
            bool isDouble = doubleValid.IsValid(str);
            if (!isDouble)
            {
                errorMessage = doubleValid.ErrorMessage;
                return false;
            }
            bool isValid = Double.Parse(str) >= 0;
            if (!isValid)
                errorMessage = "Число меньше 0";

            return isValid;
        }
    }
}
