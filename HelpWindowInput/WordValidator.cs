using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpWindowInput
{
    public class WordValidator : IStringValidator
    {
        string errorMessage;
        public string ErrorMessage { get => errorMessage; }

        public bool IsValid(string word)
        {
            if (word == "")
            {
                errorMessage = "Ввод пустой";
                return false;
            }
            foreach (char c in word)
                if (!Char.IsLetter(c))
                {
                    errorMessage = "Введены не только буквы";
                    return false;
                }

            return true;
        }
    }
}
