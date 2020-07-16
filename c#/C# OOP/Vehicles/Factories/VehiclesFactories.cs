using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Models.Contracts;

namespace Vehicles.Factories
{
    public class VehiclesFactories
    {
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle curVehicle = null;

            if(type == "Car")
            {
                curVehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if(type == "Truck")
            {
                curVehicle = new Truck(fuelQuantity, fuelConsumption);            
            }

            return curVehicle;
        }
    }
}
