using System;
using System.Collections.Generic;
using System.Linq;

namespace _1557._Minimum_Number_of_Vertices_to_Reach_All_Nodes
{
    class Program
    {
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            List<bool> indegree = new List<bool>(new bool[n]);
            foreach (var u in edges)
            {
                indegree[u[1]] = true;
            }

            return indegree.Select((val, index) => (val, index)).Where(x => x.val.Equals(false)).Select(x => x.index).ToList();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            IList<IList<int>> adj = new List<IList<int>>();
            //[0,1],[0,2],[2,5],[3,4],[4,2]
            adj.Add(new List<int> { 0, 1 });
            adj.Add(new List<int> { 0, 2 });
            adj.Add(new List<int> { 2, 5 });
            adj.Add(new List<int> { 3, 4 });
            adj.Add(new List<int> { 4, 2 });

            Console.WriteLine(program.FindSmallestSetOfVertices(6, adj));
        }
    }
}
