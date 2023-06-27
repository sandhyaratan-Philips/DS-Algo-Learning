using System;

namespace _1575._Count_All_Possible_Routes
{
    class Program
    {
        int n = 0;
        int[][] t;
        int mod = 1_000_000_000;
        public int CountRoutes(int[] locations, int start, int finish, int fuel)
        {
            t = new int[101][];
            for (int i = 0; i < 101; i++)
            {
                t[i] = new int[201];
                Array.Fill(t[i], -1);
            }
            n = locations.Length;
            return solve(locations, start, finish, fuel);
        }

        private int solve(int[] locations, int idx, int finish, int fuel)
        {
            if (fuel < 0)
                return 0;
            if (t[idx][fuel] != -1)
                return t[idx][fuel];

            int ans = 0;

            if (idx == finish)
                ans += 1;

            for (int i = 0; i < n; i++)
            {
                if (idx != i)
                    ans = (ans + solve(locations, i, finish, fuel - Math.Abs(locations[idx] - locations[i]))) % mod;
            }

            return t[idx][fuel] = ans;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CountRoutes(new int[] { 4, 3, 1 }, 1, 0, 6));

            Console.WriteLine("Hello World!");
        }
    }
}
