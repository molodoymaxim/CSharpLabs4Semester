using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace лаба5_6_с_шарп.Models
{
    public class Conveyors
    {
        public Queue<Parts> ConveyorParts = new();  // Детали конвеера
        public Stack<Parts> Reserve = new();  // Запас деталей конвеера
        public Parts Conveyor = new();
        public const int Step = 90;  // Шаг конвеера по оси Y
        public const int NumParts = 5;   // Колличество деталей на конвеере
        public const int Hitbox = 100;   // Колличество единиц для починки
        public const float Reliability = 0.995f;   // Надёжность конвеера(вероятность не сломаться при движении деталей)
        public bool Load { get; set; }   // True - Конвеер загружен, False - пустой
        public bool WorkStatus { get; set; }   // True - Конвеер исправен, False - сломан
        public bool RepairStatus { get; set; }   // True - Конвеер ремонттируется, False - Не ремонтируется
    }
}
