using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class NthPower
    {
        public double GetNthPower(int x,int n)
        {
            if(n==0) return 1;
            return GetNthPower(x,n-1)*x;
        }
    }
}
