using System;
using System.Collections.Generic;
using System.Linq;

namespace Max_Coins
{
    class Program
    {
        // solve by 0-1 knapsack in nlog n
        int maxCoins(int n, List<List<int>> ranges)
        {
            List<List<int>> coins = ranges.OrderBy(y => y[0]).ToList();

            int l = coins[0][0];
            int r = coins[0][1];
            int coin = coins[0][2];
            int sum = 0;


            return sum;
        }
        static void Main(string[] args)
        {
            List<List<int>> coin = new List<List<int>>();
            //V = 5
            //coin = {{1,3,4},{2,3,5},{3,4,2},{5,8,9},{2,8,10}}
            coin.Add(new List<int> { 1, 3, 4 });
            coin.Add(new List<int> { 2, 3, 5 });
            coin.Add(new List<int> { 3, 4, 2 });
            coin.Add(new List<int> { 5, 8, 9 });
            coin.Add(new List<int> { 2, 8, 10 });

            Program program = new Program();

            Console.WriteLine(program.maxCoins(5, coin));//5+9=14
        }
    }
}
