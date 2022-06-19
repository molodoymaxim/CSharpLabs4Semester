using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeansTranporation
{
    public abstract class PublicTransport : TransportVehicle
    {
        private double price_;
        private double priceTicket_;
        private double income_;
        private double consumption_;
        private int id_;

        public double Price
        {
            get => price_;
            set
            {
                if (value<0)
                    throw new ArgumentException("Invalid input!");
                price_ = value;
            }
        }

        public double PriceTicket
        {
            get => priceTicket_;
            set
            {
                if (value<0)
                    throw new InvalidOperationException("Invalid input!");
                priceTicket_ = value;
            }
        }

        public double Income
        {
            get => income_;
            set
            {
                if (value<0)
                    throw new InvalidOperationException("Invalid input!");
                income_ = value;
            }
        }

        public double Consumption
        {
            get => consumption_;
            set
            {
                if (value<0)
                    throw new InvalidOperationException("Invalid input!");
                consumption_ = value;
            }
        }

        public int Id
        {
            get => id_;
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Invalid input!");

                id_ = value;
            }
        }

        public abstract double Tax();

        public void Copy(TransportVehicle other)
        {
            Price = other.Price;

            if (other is PublicTransport)
            {
                PublicTransport otherPublicTransport=other as PublicTransport;
                PriceTicket = otherPublicTransport.PriceTicket;
                Income = otherPublicTransport.Income;
                Consumption = otherPublicTransport.Consumption;
            }
        }

        public double GrandTotal()
        {
            return Income-Consumption;
        }
    }
}
