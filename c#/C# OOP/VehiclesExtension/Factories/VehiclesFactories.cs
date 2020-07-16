using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using VehiclesExtension.Models;

namespace Vehicles.Factories
{
    public class VehiclesFactories
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle curVehicle = null;

            if(type == "Car")
            {
                curVehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if(type == "Truck")
            {
                curVehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);            
            }
            else if (type == "Bus")
            {
                curVehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return curVehicle;
        }
    }
}
