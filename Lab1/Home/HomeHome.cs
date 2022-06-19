using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Home
{
    public class HomeHome
    {
        DoorHome doorHome;
        WindowHome windowHome;
        public HomeHome()
        {
            doorHome = new DoorHome();
            windowHome = new WindowHome();
        }

        public void ChangeNumDoor(int numDoors_)
        {
            doorHome.ChangeNumDoors(numDoors_);
        }
        public void ChangeDoorStatus(bool status_)
        {
            if (status_)
                doorHome.OpenD();
            else
                doorHome.CloseD();
        }
        public void ChangeNumWin(int numWin_)
        {
            windowHome.ChangeNumWin(numWin_);
        }

        //public string IsOpenDoor
        //{
        //    get
        //    {
        //        if (doorHome.OpenD())
        //            return "Дверь открыта";
        //        if (doorHome.CloseD())
        //            return "Дверь закрыта";
        //    }
        //}
    }
}
