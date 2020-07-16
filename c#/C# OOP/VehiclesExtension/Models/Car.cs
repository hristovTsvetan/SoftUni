using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double ADDITION_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double litersPerKm, double tankCapacity, bool isAirConditionEn = true)
            : base(fuelQuantity, litersPerKm, tankCapacity, isAirConditionEn)
        {
            this.AdditionalFuelConsumption = ADDITION_CONSUMPTION;
        }

    }
}
