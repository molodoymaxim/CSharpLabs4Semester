using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    public class DoorHome
    {
        bool isDoor { get; set; }
        int numDoors { get; set; }

        
        public DoorHome()
        {
            Random rand = new Random();
            numDoors = 0;
            isDoor = false;
        }

        public DoorHome(bool openOrClose_, int numdoors_)
        {
            isDoor = openOrClose_;
            numDoors = numdoors_;
        }

        public void ChangeNumDoors(int numDoors_)
        {
            numDoors = numDoors_;
        }

        public void OpenD()
        {
            isDoor = true;
        }

        public void CloseD()
        {
            isDoor = false;
        }
    }
}
