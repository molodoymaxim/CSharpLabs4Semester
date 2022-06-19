using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpWindowInput
{
    public interface IStringValidator
    {
        bool IsValid(string str);
        string ErrorMessage { get; }
    }
}
