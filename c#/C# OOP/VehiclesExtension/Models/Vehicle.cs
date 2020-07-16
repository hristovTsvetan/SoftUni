using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Contracts;
using VehiclesExtension.Common;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity, bool isAirConditionEn = true)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKm;
            this.TankCapacity = tankCapacity;
            this.IsAirConditionEnable = isAirConditionEn;
        }

        public bool IsAirConditionEnable { get; set; }

        public double AdditionalFuelConsumption { get; protected set; }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            private set
            {
                if(value < this.FuelQuantity)
                {
                    this.FuelQuantity = 0;
                }

                this.tankCapacity = value;
            }
        }

        public virtual string Driving(double distance)
        {
            double consumptionPerKm = this.FuelConsumption;

            double neededFuel = consumptionPerKm * distance;

            if(this.IsAirConditionEnable)
            {
                neededFuel += distance * this.AdditionalFuelConsumption;
            }

            if (neededFuel > this.FuelQuantity)
            {
                return string.Format("{0} needs refueling", this.GetType().Name);
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public void Refueling(double fuelQuantity)
        {
            if(fuelQuantity <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceptionNegativeValueFuel);
            }

            double freeTankCapacity = this.TankCapacity - this.FuelQuantity;

            if(freeTankCapacity < fuelQuantity)
            {
                string exMessage = string.Format(ExceptionMessages.ExceptionNoFreeCapacity, fuelQuantity);
                throw new InvalidOperationException(exMessage);
            }
            if (fuelQuantity > 0)
            {
                if(this.GetType().Name == "Truck")
                {
                    fuelQuantity *= 0.95;
                }

                this.FuelQuantity += fuelQuantity;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }

    }
}
