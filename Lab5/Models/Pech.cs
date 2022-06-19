using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Pech: ActionModel
    {
        public bool IsIll { get; internal set; }

        public int BreakDownIndex { get; internal set; }

        public Pech(Action<string> Notification, float defaultX, float defaultY)
            : base(Notification, defaultX, defaultY)
        { }

        public bool WaitFix { get; internal set; }

        public void RandomSick(Random random)
        {
            // 30% закончатся ресы
            // 0..9  в сумме 10
            if (random.Next(0, 10) < 3)
            {
                BreakDownIndex = random.Next(0, BreakDown.AllBreakDown.Length);
                IsIll = true;
                WaitFix = false;
            }
        }

        // будет проверять занят или нет, если нет, то будет задавать точку возвращения
        protected override void CheckEvents()
        {
            if (!IsLocked)
            {
                ToX=defX;
                ToY=defY;
            }
        }
    }
}
