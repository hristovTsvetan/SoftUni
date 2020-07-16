using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double litersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKm;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption  { get; protected set; }

        public string Driving(double distance)
        {
            double consumptionPerKm = this.FuelConsumption;
            double neededFuel = consumptionPerKm * distance;

            if (neededFuel > this.FuelQuantity)
            {
                return string.Format("{0} needs refueling", this.GetType().Name);
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refueling(double fuelQuantity)
        {
            if(fuelQuantity > 0)
            {
                this.FuelQuantity += fuelQuantity;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }

    }
}
