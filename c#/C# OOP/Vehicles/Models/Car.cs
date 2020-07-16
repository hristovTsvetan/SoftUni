using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double ADDITION_SUMMER_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double litersPerKm)
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

    }
}
