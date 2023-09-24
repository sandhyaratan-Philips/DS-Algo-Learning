using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Conversion
    {
        public void ToBinary(int num)
        {
            if(num==0) return;
            ToBinary(num / 2);
            Console.WriteLine(num%2);
        }

        public void ToOctal(int num)
        {
            if (num == 0) return;
            ToBinary(num / 8);
            Console.WriteLine(num % 8);
        }

        public void ToHexa(int num)
        {
            if (num == 0) return;
            ToBinary(num / 8);
            Console.WriteLine(num % 8);
        }
    }
}
