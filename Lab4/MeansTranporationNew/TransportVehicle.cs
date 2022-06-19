using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeansTranporationNew
{
    public interface TransportVehicle
    {
        int Id { get; set; }
        double Price { get; set; }

        // налог на транспорт, зависит от итоговой зп
        double Tax();

        void Copy(TransportVehicle other);
    }
}
