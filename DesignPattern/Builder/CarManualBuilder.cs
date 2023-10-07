using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class CarManualBuilder:IBuilder
    {
        private Manual _manual = null;
        public void reset()
        {
            _manual = new Manual();
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
        public Manual getProduct()
        {
            Manual product = this._manual;
            this.reset();
            return product;
        }
    }
}
