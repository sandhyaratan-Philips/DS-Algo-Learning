using System;

namespace _956._Tallest_Billboard_Memorization
{
    class Program
    {
        int n;
        int[][] t;
        public int TallestBillboard(int[] rods)
        {
            t = new int[21][];

            for (int i = 0; i < 21; i++)
            {
                t[i] = new int[10003];
                Array.Fill(t[i], -1);
            }


            n = rods.Length;
            return solve(0, 0, rods) / 2;
        }

        private int solve(int idx, int diff, int[] rods) //take l1-l2=diff
        {
            if (idx >= n)
            {
                if (diff == 0)
                    return 0;

                return int.MinValue;
            }
            if (t[idx][diff + 5000] != -1)
                return t[idx][diff + 5000];


            int ans = 0;
            int noRod = solve(idx + 1, diff, rods);
            int takeRodL1 = rods[idx] + solve(idx + 1, diff + rods[idx], rods);
            int takeRodL2 = rods[idx] + solve(idx + 1, diff - rods[idx], rods);
            ans = Math.Max(Math.Max(takeRodL1, takeRodL2), noRod);
            return t[idx][diff + 5000] = ans;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.TallestBillboard(new int[] { 1, 2, 3, 4, 5, 6 }));
            Console.WriteLine("Hello World!");
        }
    }
}
