using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Pirint_1To_N
    {
        public void Print(int n) {
            if (n == 0) return;
            Print(n-1);
            Console.WriteLine(n);
        }
    }
}
