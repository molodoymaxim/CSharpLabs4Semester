using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Loader : Employee
    {
        public Loader(Action<string> Notification, float defX, float defY, List<Pech> employee, object employeeLocker)
            : base(Notification, defX, defY, employee, employeeLocker)
        {
            for (int i = 0; i < BreakDown.AllBreakDown.Length; i++)
                if (BreakDown.AllBreakDown[i].Contains("топливо"))
                    BreakIndexes.Add(i);
        }
    }
}
