using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Model
    {
        public float X { get; set; }    
        public float Y { get; set; }   
        public bool IsLocked { get; internal set; }
        public bool IsCanceled { get; set; }

        public abstract void Start();
        public Action<string> Notification;
        public Model(Action<string> Notification)
        {
            this.Notification = Notification;
        }
    }
}
