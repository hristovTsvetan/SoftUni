using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Contracts
{
    public interface IVehicle : IDrivable, IRefuelable
    {
        double FuelConsumption { get; }

        double FuelQuantity { get; }
    }
}
