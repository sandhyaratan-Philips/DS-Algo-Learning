using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    internal class Bike : IVehicle
    {
        private readonly int wheel;
        public Bike()
        {
            wheel = 2;
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
