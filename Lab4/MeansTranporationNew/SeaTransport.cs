using MeansTranporationNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeansTranporationNew
{
    public class SeaTransport: PublicTransport
    {
        public bool HasCabin { get; set; }

        public override double Tax()
        {
            return base.Tax() + (HasCabin ? 500 : 0);
        }

        public int NumCabins( int numCabins)
        {
            return numCabins;
        }

        public override void Copy(TransportVehicle other)
        {
            base.Copy(other);

            if (other is SeaTransport seaTransport)
            {
                HasCabin = seaTransport.HasCabin;
            }
        }
    }
}
