using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Factories;
using Vehicles.Models;
using Vehicles.Models.Contracts;

namespace Vehicles.Core
{
    public class Engine
    {
        IVehicle car;
        IVehicle truck;
        VehiclesFactories vehicleFactory;

        public Engine()
        {
            vehicleFactory = new VehiclesFactories();
        }
        
        public void Run()
        { 
            car = CreateVehicles("Car");
            truck = CreateVehicles("Truck");
            Actions();
            Print();
        }

        private void Print()
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private IVehicle CreateVehicles(string type)
        {
            string[] input = Console.ReadLine()
                                .Split()
                                .ToArray();

            double fuelQuantity = double.Parse(input[1]);
            double consumption = double.Parse(input[2]);

            return vehicleFactory.CreateVehicle(type, fuelQuantity, consumption);

        }

        private void Actions()
        {
            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string action = input[0];
                string typeVehicle = input[1];
                double quantDistance = double.Parse(input[2]);

                switch (typeVehicle)
                {
                    case "Car":
                        if (action == "Drive")
                        {
                            Drive(this.car, quantDistance);
                        }
                        else if (action == "Refuel")
                        {
                            Refuel(this.car, quantDistance);
                        }
                        break;
                    case "Truck":
                        if (action == "Drive")
                        {
                            Drive(this.truck, quantDistance);
                        }
                        else if (action == "Refuel")
                        {
                            Refuel(this.truck, quantDistance);
                        }
                        break;
                }

            }
        }

        public void Drive(IVehicle curVehicle, double distance)
        {
            Console.WriteLine(curVehicle.Driving(distance));
        }

        public void Refuel(IVehicle curVehicle, double quantity)
        {
            curVehicle.Refueling(quantity);
        }
    }
}
