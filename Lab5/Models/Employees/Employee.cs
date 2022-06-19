using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Employee: ActionModel, IEmployee
    {
        private readonly List<Pech> _employees;
        private readonly object employeeLocker;

        Pech breakPech;

        public Employee(Action<string> Notification, float defaultX, float defaultY, List<Pech> _employees, object employeeLocker)
           : base(Notification, defaultX, defaultY)
        {
            BreakIndexes = new List<int>();

            this._employees = _employees;
            this.employeeLocker = employeeLocker;
        }

        public List<int> BreakIndexes { get; }

        void Fixing()
        {
            if (IsCome())
            {
                Notification($"Работник {Name} ремонтирует печь " +
                        $"{breakPech.Name}");

                Task.Delay(5 * 1000).Wait();

                breakPech.IsIll = false;
                breakPech.IsLocked = false;

                Notification($"Печь {breakPech.Name} отремонтирована");

                // доктор ничего не делает
                DoSomthing = null;
                IsLocked = false;

                //return to hospitel
                ToX = defX;
                ToY = defY;
            }
        }

        protected override void CheckEvents()
        {
            if (IsLocked)
                return;

            lock (employeeLocker)
            {
                // если болеет и индекс болезни такой же
                breakPech = _employees
                    .FirstOrDefault(emplyee => emplyee.IsIll &&
                    BreakIndexes.Contains(emplyee.BreakDownIndex)
                    && !emplyee.WaitFix);

                if (breakPech != null)
                {
                    // сразу пометим, что он ждёт лечения, чтобы другие врачи не пришли его лечить
                    breakPech.WaitFix = true;
                    ToX = breakPech.X;
                    ToY = breakPech.Y;

                    IsLocked = true;
                    DoSomthing = Fixing;

                    Notification($"Работник {Name} пошёл ремонтировать печь " +
                        $"{breakPech.Name}");
                }
            }
        }


    }
}
