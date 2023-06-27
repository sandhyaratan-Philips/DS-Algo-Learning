using System;

namespace _956._Tallest_Billboard
{
    class Program
    {
        int n;
        public int TallestBillboard(int[] rods)
        {
            n = rods.Length;
            return solve(0, 0, 0, rods);
        }

        private int solve(int idx, int l1, int l2, int[] rods)
        {
            if (idx >= n)
                if (l1 == l2)
                    return l1;
                else
                    return 0;
            int ans = 0;
            int noRod = solve(idx + 1, l1, l2, rods);
            int takeRodL1 = solve(idx + 1, l1 + rods[idx], l2, rods);
            int takeRodL2 = solve(idx + 1, l1, rods[idx] + l2, rods);
            ans = Math.Max(Math.Max(takeRodL1, takeRodL2), noRod);
            return ans;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.TallestBillboard(new int[] { 1, 2, 3, 4, 5, 6 }));
            Console.WriteLine("Hello World!");
        }
    }
}
