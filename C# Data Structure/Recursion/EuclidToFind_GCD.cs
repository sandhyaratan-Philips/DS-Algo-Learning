using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class EuclidToFind_GCD
    {
        public int GetGcd(int a,int b)
        {
            if(b==0) return a;
            return GetGcd(b, a % b);
        }
    }
}
