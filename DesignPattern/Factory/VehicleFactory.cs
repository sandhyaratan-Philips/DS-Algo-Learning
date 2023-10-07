using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    internal class VehicleFactory
    {
        public static IVehicle GetVehicle(string Type)
        {
            IVehicle vehicle = null;
            if (Type.ToLower().Equals("bike"))
            {
                vehicle = new Bike();
            }
            else if (Type.ToLower().Equals("car"))
            {
                vehicle = new Car();
            }
            return vehicle;
        }
    }
}
