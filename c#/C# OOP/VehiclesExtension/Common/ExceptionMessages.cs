using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Common
{
    public static class ExceptionMessages
    {
        public static string ExceptionNegativeValueFuel =
            "Fuel must be a positive number";

        public static string ExceptionNoFreeCapacity =
            "Cannot fit {0} fuel in the tank";
    }
}
