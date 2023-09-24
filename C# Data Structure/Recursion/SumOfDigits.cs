using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class SumOfDigits
    {
       public int GetSumOfDigits(int num) {
            if(num/10 == 0) return num;

            int leastSignificant=num%10;
            return leastSignificant+GetSumOfDigits(num/10);
        }
    }
}
