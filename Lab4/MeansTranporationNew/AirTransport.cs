using MeansTranporationNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeansTranporationNew
{
    public class AirTransport: PublicTransport
    {
        public bool HasLunch { get; set; }

        public override double Tax()
        {
            return base.Tax() + (HasLunch ? 500 : 0);
        }

        public int NumPlaces(int place_)
        {
            if (place_ == 0)
                return 0;
            return place_;
        }

        public override void Copy(TransportVehicle other)
        {
            base.Copy(other);

            if (other is AirTransport airTransport)
            {
                HasLunch = airTransport.HasLunch;
            }
        }

    }
}
