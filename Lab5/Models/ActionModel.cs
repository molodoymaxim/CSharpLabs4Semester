using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class ActionModel : Model
    {
        protected float defX, defY;
        public float ToX { get; internal set; }
        public float ToY { get; internal set; }

        public ActionModel(Action<string> Notification, float defX, float defY) : base(Notification)
        {
            this.defX = defX;
            this.defY = defY;

            X = defX;
            Y = defY;

            ToX = defX;
            ToY = defY;

            DoSomthing=null;
        }

        public string Name { get; set; }

        const float maxSpeed = 3;

        protected Action DoSomthing;

        protected abstract void CheckEvents();

        public bool IsCome()
        {
            return Math.Abs(X - ToX) < 5 && Math.Abs(Y - ToY) < 5;
        }

        public void Go()
        {
            if (IsCome())
                return;

            if (X - ToX != 0)
            {
                Y += maxSpeed * (ToY - Y) / Math.Abs(X - ToX);
                X += maxSpeed * Math.Sign(ToX - X);
            }
            else
            {
                X += maxSpeed * (ToX - X) / Math.Abs(Y - ToY);
                Y += maxSpeed * Math.Sign(Y - ToY);
            }
        }

        public override void Start()
        {
            while (!IsCanceled)
            {

                CheckEvents();
                Go();

                DoSomthing?.Invoke();

                Task.Delay(30).Wait();
            }
        }
    }
}
