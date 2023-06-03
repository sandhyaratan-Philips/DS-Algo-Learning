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

        //Input: n = 6, headID = 2, manager = [2,2,-1,2,2,2], informTime = [0,0,1,0,0,0]
        //        Output: 1
        //Explanation: The head of the company with id = 2 is the direct manager of all the employees in the company and needs 1 minute to inform them all.
        //The tree structure of the employees in the company is shown.
        static void Main(string[] args)
        {
            Program program = new Program();
            program.NumOfMinutes(6, 2, new int[] { 2, 2, -1, 2, 2, 2 }, new int[] { 0, 0, 1, 0, 0, 0 });
            Console.WriteLine("Hello World!");
        }
    }
}
