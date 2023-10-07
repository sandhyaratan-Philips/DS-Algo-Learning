using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal interface IBuilder
    {
        void reset();
    void setSeats();
        void setEngine();
        void setTripComputer();
        void setGPS();
    }
}
