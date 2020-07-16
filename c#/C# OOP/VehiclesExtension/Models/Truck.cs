using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double ADDITION_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity, bool isAirConditionEn = true)
            : base(fuelQuantity, litersPerKm, tankCapacity, isAirConditionEn)
        {
            this.AdditionalFuelConsumption = ADDITION_CONSUMPTION;
        }

    }
}
