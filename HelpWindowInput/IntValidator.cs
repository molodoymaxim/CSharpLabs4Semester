using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpWindowInput
{
    public class IntValidator : IStringValidator
    {
        string errorMessage;
        public string ErrorMessage { get => errorMessage; }

        public bool IsValid(string str)
        {
            int res;
            bool isDouble = Int32.TryParse(str, out res);
            if (!isDouble)
                errorMessage = "Введено не целое число";

            return isDouble;
        }
    }
}
