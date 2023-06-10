using System;
using System.Collections.Generic;

namespace _1376._Time_Needed_to_Inform_All_Employees
{
    class Program
    {
        int maxTime = int.MinValue;
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            List<List<int>> adj = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<int>());
            }
            for (int i = 0; i < n; i++)
            {
                if (manager[i] != -1)
                    adj[manager[i]].Add(i);
            }

            DFS(adj, informTime, headID, 0);
            return maxTime;

        }

        private void DFS(List<List<int>> adj, int[] informTime, int curr, int Time)
        {
            maxTime = Math.Max(maxTime, Time);

            foreach (var v in adj[curr])
            {
                DFS(adj, informTime, v, Time + informTime[curr]);
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
