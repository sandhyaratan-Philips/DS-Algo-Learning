using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Director
    {
        public void constructSportsCar(IBuilder builder)
        {
            builder.reset();
            builder.setSeats();
            builder.setEngine();
            builder.setTripComputer();
            builder.setGPS();
        }

        public void constructSUV(IBuilder builder) { }

    }
}
