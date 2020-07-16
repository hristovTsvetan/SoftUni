using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double ADDITION_SUMMER_CONSUMPTION = 1.6;
        private const double FUEL_CAPACITY = 0.95;

        public Truck(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm)
        {
        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + ADDITION_SUMMER_CONSUMPTION;
            }
        }

        public override void Refueling(double fuelQuantity)
        {
            base.Refueling(fuelQuantity * FUEL_CAPACITY);
        }
    }
}
