using System;

namespace _309._Best_Time_to_Buy_and_Sell_Stock_with_Cooldown_bottom_up
{
    class Program
    {

        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n == 0 || n == 1)
                return 0;

            int[] t = new int[n];

            t[0] = 0;
            t[1] = Math.Max(prices[1] - prices[0], 0);
            //sell
            for (int i = 2; i < n; i++)
            {
                t[i] = t[i - 1];
                for (int j = 0; j <= i - 1; j++)
                {
                    int today_profit = prices[i] - prices[j];
                    if (j >= 2) int prev_profit = t[j - 2];
                    t[i] = Math.Max(t[i], Math.Max(today_profit, prev_profit));
                }
            }
            return t[n - 1];

        }



        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaxProfit(new int[] { 1, 2, 3, 0, 2 }));
            Console.WriteLine("Hello World!");
        }
    }
}
