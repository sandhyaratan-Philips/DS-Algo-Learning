using System;
using System.Collections.Generic;

namespace _802._Find_Eventual_Safe_States_DFS
{
    class Program
    {
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            List<List<int>> adj = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<int>());
                foreach (int node in graph[i])
                {
                    adj[i].Add(node);
                }
            }

            bool[] visit = new bool[n];
            bool[] inStack = new bool[n];

            for (int i = 0; i < n; i++)
            {
                DFS(visit, i, adj, inStack);
            }

            List<int> safeNodes = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (!inStack[i])
                {
                    safeNodes.Add(i);
                }
            }
            return safeNodes;
        }

        private bool DFS(bool[] visited, int node, List<List<int>> adj, bool[] inStack)
        {
            if (inStack[node])
            {
                return true;
            }
            if (visited[node])
            {
                return false;
            }
            // Mark the current node as visited and part of current recursion stack.
            visited[node] = true;
            inStack[node] = true;
            foreach (int neighbor in adj[node])
            {
                if (DFS(visited, neighbor, adj, inStack))
                {
                    return true;
                }
            }
            inStack[node] = false;
            return false;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EventualSafeNodes(new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 5 }, new int[] { 0 }, new int[] { 5 }, new int[] { }, new int[] { } });
            Console.WriteLine("Hello World!");
        }
    }
}
