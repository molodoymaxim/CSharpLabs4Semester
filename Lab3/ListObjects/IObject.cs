using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeansTranporation;

namespace ListObjects
{
    public interface IObject
    {
        IEnumerable<TransportVehicle> GetAll();
        TransportVehicle Get(int id);
        void Add(TransportVehicle item);
        void Update(TransportVehicle item);
        void Delete(int id);
    }
}
