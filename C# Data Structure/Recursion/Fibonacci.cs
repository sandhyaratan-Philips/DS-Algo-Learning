using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Fibonacci
    {
        int[] memo;
        public int GetFibonacci(int n) {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return GetFibonacci(n- 1)+GetFibonacci(n-2);

        }

        public void Fib(int num)
        {
            memo=new int[num+2];
            Array.Fill(memo, -1);
            memo[0] = 0;
            memo[1] = 1;
            Console.WriteLine(GetFibonacciWithDP(num));
        }
        public int GetFibonacciWithDP(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (memo[n]!=-1)
                return memo[n];
            return memo[n]=GetFibonacci(n - 1) + GetFibonacci(n - 2);

        }

    }
}
