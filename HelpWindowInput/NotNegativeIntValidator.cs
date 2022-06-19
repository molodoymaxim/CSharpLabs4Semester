using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpWindowInput
{
    public class NotNegativeIntValidator : IStringValidator
    {
        IntValidator intValid = new IntValidator();

        string errorMessage;
        public string ErrorMessage { get => errorMessage; }

        public bool IsValid(string str)
        {
            bool isInt = intValid.IsValid(str);
            if (!isInt)
            {
                errorMessage = intValid.ErrorMessage;
                return false;
            }
            bool isValid = Int32.Parse(str) >= 0;
            if (!isValid)
                errorMessage = "Число меньше 0";

            return isValid;
        }
    }
}
