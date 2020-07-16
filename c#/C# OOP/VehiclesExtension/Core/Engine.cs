using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        Vehicle car;
        Vehicle truck;
        Vehicle bus;
        VehiclesFactories vehicleFactory;

        public Engine()
        {
            vehicleFactory = new VehiclesFactories();
        }

        public void Run()
        {
            car = CreateVehicles("Car");
            truck = CreateVehicles("Truck");
            bus = CreateVehicles("Bus");
            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                try
                {
                    Actions(input);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

            Print();
        }

        private void Print()
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private Vehicle CreateVehicles(string type)
        {
            string[] input = Console.ReadLine()
                                .Split()
                                .ToArray();

            double fuelQuantity = double.Parse(input[1]);
            double consumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            return vehicleFactory.CreateVehicle(type, fuelQuantity, consumption, tankCapacity);

        }

        private void Actions(string[] input)
        {

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
                case "Bus":
                    if (action == "Drive")
                    {
                        Drive(this.bus, quantDistance);
                    }
                    else if (action == "Refuel")
                    {
                        Refuel(this.bus, quantDistance);
                    }
                    else if (action == "DriveEmpty")
                    {
                        this.bus.IsAirConditionEnable = false;
                        Drive(this.bus, quantDistance);
                    }
                    break;


            }
        }

        public void Drive(Vehicle curVehicle, double distance)
        {
            Console.WriteLine(curVehicle.Driving(distance));
        }

        public void Refuel(Vehicle curVehicle, double quantity)
        {
            curVehicle.Refueling(quantity);
        }
    }
}
