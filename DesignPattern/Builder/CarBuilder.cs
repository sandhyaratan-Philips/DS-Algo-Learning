using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class CarBuilder : IBuilder
    {
        private Car _car = null;
        public void reset()
        {
            _car = new Car();
        }

        public void setEngine()
        {
            throw new NotImplementedException();
        }

        public void setGPS()
        {
            throw new NotImplementedException();
        }

        public void setSeats()
        {
            throw new NotImplementedException();
        }

        public void setTripComputer()
        {
            throw new NotImplementedException();
        }
         public Car getProduct()
        {
            Car product = this._car;
            this.reset();
            return product;
        }
    }
}
