﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Contracts
{
    public interface IRefuelable
    {
        void Refueling(double fuelQuantity);
    }
}
