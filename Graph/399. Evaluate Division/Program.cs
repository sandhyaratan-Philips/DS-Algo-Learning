using System;
using System.Collections.Generic;

namespace _399._Evaluate_Division
{
    class Program
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, List<KeyValuePair<string, double>>> adj = new Dictionary<string, List<KeyValuePair<string, double>>>();
            int n = equations.Count;
            for (int i = 0; i < n; i++)
            {
                string u = equations[i][0]; //a
                string v = equations[i][1]; //b

                double val = values[i];

                if (!adj.ContainsKey(u))
                    adj.Add(u, new List<KeyValuePair<string, double>> { new KeyValuePair<string, double>(v, val) });
                else
                    adj[u].Add(new KeyValuePair<string, double>(v, val));

                if (!adj.ContainsKey(v))
                    adj.Add(v, new List<KeyValuePair<string, double>> { new KeyValuePair<string, double>(u, 1 / val) });
                else
                    adj[v].Add(new KeyValuePair<string, double>(u, 1 / val));

            }

            List<double> result = new List<double>();

            foreach (var query in queries)
            {
                string src = query[0];
                string dest = query[1];

                double ans = -1;
                double product = 1;

                if (adj.ContainsKey(src))
                {
                    List<string> visited = new List<string>();
                    DFS(adj, src, dest, visited, product, ref ans);
                }
                result.Add(ans);

            }


            return result.ToArray();
        }

        private void DFS(Dictionary<string, List<KeyValuePair<string, double>>> adj, string src, string dest, List<string> visited, double product, ref double ans)
        {
            if (visited.Contains(src))
                return;

            visited.Add(src);

            if (src == dest)
            {
                ans = product;
                return;
            }

            foreach (var p in adj[src])
            {
                string v = p.Key;
                double val = p.Value;

                DFS(adj, v, dest, visited, product * val, ref ans);


            }



        }

        //Input: equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
        //Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
        //        Explanation: 
        //Given: a / b = 2.0, b / c = 3.0
        //queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ?
        //return: [6.0, 0.5, -1.0, 1.0, -1.0 ]

        static void Main(string[] args)
        {
            Program program = new Program();

            program.CalcEquation(new List<IList<string>> { new List<string> { "a", "b" }, new List<string> { "b", "c" } }, new double[] { 2.0, 3.0 }, new List<IList<string>> { new List<string> { "a", "c" }, new List<string> { "b", "a" }, new List<string> { "a", "e" }, new List<string> { "a", "a" }, new List<string> { "x", "x" } });
            Console.WriteLine("Hello World!");
        }
    }
}
