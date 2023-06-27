using System;

namespace _309._Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
{
    class Program
    {
        int[][] t;
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            t = new int[5001][];
            for (int i = 0; i < 5001; i++)
            {
                t[i] = new int[2];
                Array.Fill(t[i], -1);
            }

            return solve(prices, 0, n, 1);

        }

        private int solve(int[] prices, int day, int n, int buy)
        {
            if (day >= n)
                return 0;

            if (t[day][buy] != -1)
                return t[day][buy];

            int profit = 0;
            if (buy == 1)
            {
                int take = solve(prices, day + 1, n, 0) - prices[day];
                int not_take = solve(prices, day + 1, n, 1);
                profit = Math.Max(Math.Max(take, not_take), profit);
            }
            else
            {
                int sell = solve(prices, day + 2, n, 1) + prices[day];
                int not_sell = solve(prices, day + 1, n, 0);
                profit = Math.Max(Math.Max(sell, not_sell), profit);
            }
            return t[day][buy] = profit;

        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaxProfit(new int[] { 1, 2, 3, 0, 2 }));
            Console.WriteLine("Hello World!");
        }
    }
}
