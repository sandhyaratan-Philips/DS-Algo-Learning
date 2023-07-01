using System;
using System.Linq;

namespace _2305._Fair_Distribution_of_Cookies
{
    class Program
    {
        int res = int.MaxValue;
        int n;
        public int DistributeCookies(int[] cookies, int k)
        {
            n = cookies.Length;
            int[] children = new int[k];

            solve(0, cookies, children, k);
            return res;
        }

        private void solve(int idx, int[] cookies, int[] children, int k)
        {
            if (idx >= n)
            {
                int unfaireness = children.Max();
                res = Math.Min(res, unfaireness);
                return;
            }
            int cookie = cookies[idx];

            for (int i = 0; i < k; i++)
            {
                children[i] += cookie;
                solve(idx + 1, cookies, children, k);
                children[i] -= cookie;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.DistributeCookies(new int[] { 6, 1, 3, 2, 2, 4, 1, 2 }, 3));
            Console.WriteLine("Hello World!");
        }
    }
}
