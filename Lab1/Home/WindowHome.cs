using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home;

namespace Home
{
    public class WindowHome
    {
        public int numWindows { get; set; }

        public WindowHome()
        {
            Random random = new Random();
            numWindows=random.Next(1,10);
        }
        public WindowHome(int numWindows_)
        {
            numWindows=numWindows_;
        }

        public void ChangeNumWin(int numWindow_)
        {
            numWindows=numWindow_;
        }
    }
}
