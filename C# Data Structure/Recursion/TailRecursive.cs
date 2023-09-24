using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{

    //A Recursive call is tail Recursive if it is last statement that execute inside the method
    internal class TailRecursive
    {
        public void print1(int n)
        {
            if (n == 0)
                return;
            print1(n - 1);
            Console.WriteLine(n);
        }
        public void print1InTailRecursive(int n)
        {
            if (n == 0)
                return;
            Console.WriteLine(n);
            print1(n - 1); //nothing to do in unwinding phase
        }
    }
}
