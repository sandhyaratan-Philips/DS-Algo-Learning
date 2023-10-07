using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    internal class Car:IVehicle
    {
        private readonly int wheel;
        public Car()
        {
            wheel = 4;
        }
        public int NumOfWheels()
        {
            return wheel;
        }

        public string VehicleType()
        {
            return "Bike";
        }
    }
}
