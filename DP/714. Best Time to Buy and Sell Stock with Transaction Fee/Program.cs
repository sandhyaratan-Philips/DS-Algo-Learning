using System;

namespace _714._Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee
{
    class Program
    {
        int[][] t;
        public int MaxProfit(int[] prices, int fee)
        {
            int n = prices.Length;
            t = new int[50001][];
            for (int i = 0; i < 50001; i++)
            {
                t[i] = new int[2];
                Array.Fill(t[i], -1);
            }
            return MaxPro(prices, 0, n, 1, fee);
        }

        private int MaxPro(int[] prices, int day, int n, int Buy, int fee)
        {
            if (day >= n)
                return 0;

            if (t[day][Buy] != -1)
                return t[day][Buy];

            int profit = 0;

            if (Buy == 1)
            {
                int take = MaxPro(prices, day + 1, n, 0, fee) - prices[day];
                int not_take = MaxPro(prices, day + 1, n, 1, fee);
                profit = Math.Max(Math.Max(profit, take), not_take);
            }
            else
            {
                int sell = MaxPro(prices, day + 1, n, 1, fee) + prices[day] - fee;
                int not_sell = MaxPro(prices, day + 1, n, 0, fee);
                profit = Math.Max(Math.Max(profit, sell), not_sell);
            }
            return t[day][Buy] = profit;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaxProfit(new int[] { 1, 3, 2, 8, 4, 9 }, 2));
            Console.WriteLine("Hello World!");
        }
    }
}
