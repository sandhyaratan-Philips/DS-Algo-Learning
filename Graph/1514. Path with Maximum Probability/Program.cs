using System;
using System.Collections.Generic;

namespace _1514._Path_with_Maximum_Probability
{
    class Program
    {
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            Dictionary<int, List<Node>> g = new Dictionary<int, List<Node>>();
            for (int i = 0; i < n; i++)
                g[i] = new List<Node>();
            for (int i = 0; i < edges.Length; i++)
            {
                g[edges[i][0]].Add(new Node(edges[i][1], succProb[i]));
                g[edges[i][1]].Add(new Node(edges[i][0], succProb[i]));
            }

            double[] prob = new double[n];
            prob[start] = 1.0;
            SortedSet<Node> queue = new SortedSet<Node>();
            queue.Add(new Node(start, prob[start]));

            while (queue.Count > 0)
            {
                Node curr = queue.Max;
                queue.Remove(curr);
                if (curr.vertex == end) return prob[curr.vertex];
                foreach (Node next in g[curr.vertex])
                {
                    if (prob[next.vertex] < prob[curr.vertex] * next.prob)
                    {
                        prob[next.vertex] = curr.prob * next.prob;
                        queue.Remove(next);
                        queue.Add(new Node(next.vertex, prob[next.vertex]));
                    }
                }
            }
            return 0.0;
        }

        public class Node : IComparable<Node>
        {
            public int vertex;
            public double prob;
            public Node(int vertex, double prob)
            {
                this.vertex = vertex;
                this.prob = prob;
            }
            public int CompareTo(Node other)
            {
                if (this.prob != other.prob)
                    return this.prob.CompareTo(other.prob);
                else
                    return this.vertex.CompareTo(other.vertex);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //n = 3, edges = [[0,1],[1,2],[0,2]], succProb = [0.5,0.5,0.3], start = 0, end = 2
            program.MaxProbability(3, new int[][] { new int[] { 0, 1 } }, new double[] { 0.5 }, 0, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
