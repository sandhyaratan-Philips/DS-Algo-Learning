using System;
using System.Collections.Generic;

namespace _210._Course_Schedule_II_using_BFS
{
    class Program
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Queue<int> q = new Queue<int>();
            List<int> inDegree = new List<int>(new int[numCourses]);
            List<List<int>> adj = new List<List<int>>();

            List<int> arr = new List<int>();
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

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                arr.Add(u);

                foreach (var v in adj[u])
                {
                    inDegree[v]--;
                    if (inDegree[v] == 0)
                    {
                        q.Enqueue(v);
                    }
                }
            }

            return (arr.Count == numCourses) ? arr.ToArray() : new int[] { };
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.FindOrder(4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } }));
        }
    }
}
