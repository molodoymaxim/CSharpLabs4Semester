using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeansTranporationNew
{
    public class TramCar : PublicTransport
    {
        public bool HasCardPayment { get; set; }

        private int numberPlaces_;

        public int NumberPlaces
        {
            get => numberPlaces_;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid input!");
                numberPlaces_ = value;
            }
        }

        public override double Tax()
        {
            return GrandTotal()*0.87;
        }

        public int SitPlace()
        {
            double b=(double)numberPlaces_*0.75;
            return (int)Math.Round(b);
        }

        public int StandingPlace()
        {
            double b = (double)numberPlaces_*0.25;
            return (int)Math.Round(b);
        }

        public new void Copy(TransportVehicle other)
        {
            base.Copy(other);

            if (other is TramCar)
            {
                TramCar otherTramCar = other as TramCar;

                HasCardPayment = otherTramCar.HasCardPayment;
                numberPlaces_= otherTramCar.NumberPlaces;
            }
        }

    }
}
