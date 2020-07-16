using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Models.Contracts;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double ADDITION_CONSUMPTION = 1.4;

        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity, bool isAirConditionEn = true)
            : base(fuelQuantity, litersPerKm, tankCapacity, isAirConditionEn)
        {
            this.AdditionalFuelConsumption = ADDITION_CONSUMPTION;
        }


        public override string Driving(double distance)
        {
            return base.Driving(distance);
        }
    }
}
