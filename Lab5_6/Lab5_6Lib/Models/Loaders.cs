using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace лаба5_6_с_шарп.Models
{
    public class Loaders
    {
        public Parts Loader = new();
        public const int Batch = 9;  // Количество товаров загружаемых погрузчиком за раз
        public int LoadBatch { get; set; } // Счётчик загруженных товаров
        public bool Loading { get; set; }    // True - погрузка производится, False - погурзка не производится
    }
}
