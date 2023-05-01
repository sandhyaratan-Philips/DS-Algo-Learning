using System;
using System.Collections.Generic;

namespace DFS
{
    class Program
    {
        public
  List<int> dfsOfGraph(int V, List<List<int>> adj)
        {
            List<bool> visited = new List<bool>();
            List<int> ans = new List<int>();
            //Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < V; i++)
            {
                visited.Add(false);
            }

            dfs(0, adj, visited, ans);
            return ans;
        }

        void dfs(int u, List<List<int>> adj, List<bool> visited, List<int> ans)
        {
            if (visited[u])
                return;
            visited[u] = true;
            ans.Add(u);
            foreach (var v in adj[u])
            {
                if (!visited[v])
                    dfs(v, adj, visited, ans);
            }
        }
        static void Main(string[] args)
        {
            List<List<int>> adj = new List<List<int>>();
            //V = 5 , adj = [[2, 3, 1] , [0], [0,4], [0], [2]]
            adj.Add(new List<int> { 2, 3, 1 });
            adj.Add(new List<int> { 0 });
            adj.Add(new List<int> { 0, 4 });
            adj.Add(new List<int> { 0 });
            adj.Add(new List<int> { 2 });

            Program program = new Program();
            program.dfsOfGraph(5, adj);



            Console.WriteLine("Hello World!");
        }
    }
}
