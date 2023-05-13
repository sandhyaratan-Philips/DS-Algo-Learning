using System;
using System.Collections.Generic;

namespace _207._Course_Schedule_using_BFS
{
    //kahn algo
    //algo: if cycle then cant complete
    class Program
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Queue<int> q = new Queue<int>();
            List<int> inDegree = new List<int>(new int[numCourses]);
            List<List<int>> adj = new List<List<int>>();
            int nodeCount = 0;
            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(new List<int>());
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                adj[prerequisites[i][1]].Add(prerequisites[i][0]);
                inDegree[prerequisites[i][0]]++;
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    q.Enqueue(i);
                }
            }
            nodeCount = q.Count;

            while (q.Count > 0)
            {
                int u = q.Dequeue();

                foreach (var v in adj[u])
                {
                    inDegree[v]--;
                    if (inDegree[v] == 0)
                    {
                        q.Enqueue(v);
                        nodeCount++;
                    }
                }
            }

            return (nodeCount == numCourses);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CanFinish(2, new int[][] { new int[] { 1, 0 } }));
        }
    }
}
