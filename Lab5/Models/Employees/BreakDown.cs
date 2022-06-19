using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class BreakDown
    {
        static string[] _allBreakDown = new string[]
        {
            "Кончились ресурсы",
            "Перегрев"
        };

        public static string[] AllBreakDown { get=> _allBreakDown; }
    }
}
