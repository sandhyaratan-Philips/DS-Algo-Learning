using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementing_Dijkstra_Algorithm_with_Priority_Queue
{
    class Program
    {
        public List<int> dijkstra(int V, List<List<List<int>>> adj, int S)
        {
            PriorityQueue<KeyValuePair<int, int>> pq = new PriorityQueue<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((x, y) => x.Key - y.Key));

            int[] result = new int[V];
            Array.Fill(result, int.MaxValue);

            result[S] = 0;
            pq.Enqueue(new KeyValuePair<int, int>(0, S));

            while (pq.Count > 0)
            {
                var t = pq.Dequeue();

                int dist = t.Key;
                int node = t.Value;

                foreach (var item in adj[node])
                {
                    int i = 0;
                    foreach (var v in adj[node])
                    {
                        if (v.Count > 0)
                        {
                            int adjNode = i;
                            int adjDist = v[0];
                            if (dist + adjDist < result[adjNode])
                            {
                                result[adjNode] = dist + adjDist;
                                pq.Enqueue(new KeyValuePair<int, int>(dist + adjDist, adjNode));
                            }
                        }
                        i++;
                    }
                }

            }


            return result.ToList();
        }
        static void Main(string[] args)
        {
            List<List<List<int>>> adj = new List<List<List<int>>>();

            for (int i = 0; i < 4; i++)
            {
                adj.Add(new List<List<int>>());
                for (int j = 0; j < 4; j++)
                {
                    adj[i].Add(new List<int>());
                }
            }
            adj[0][1].Add(9);
            adj[0][2].Add(1);
            adj[0][3].Add(1);

            adj[1][0].Add(9);
            adj[1][3].Add(3);

            adj[2][0].Add(1);
            adj[2][3].Add(2);

            adj[3][0].Add(1);
            adj[3][2].Add(2);
            adj[3][1].Add(3);

            Program program = new Program();
            program.dijkstra(4, adj, 0);
            Console.WriteLine("Hello World!");
        }

        public class PriorityQueue<T> : List<T>
        {
            private readonly IComparer<T> comparer;
            public PriorityQueue()
            {
                comparer = Comparer<T>.Default;
            }
            public PriorityQueue(IComparer<T> comparer)
            {
                this.comparer = comparer;
            }

            public PriorityQueue(int capacity)
            : base(capacity)
            {
                comparer = Comparer<T>.Default;
            }
            public PriorityQueue(int capacity, IComparer<T> comparer)
         : base(capacity)
            {
                this.comparer = comparer;
            }

            public T Peek()
            {
                return this[0];
            }

            public void AdjustHeap(int position)
            {
                int up = position;
                while (up > 0)
                {
                    int parent = (up - 1) / 2;
                    if (comparer.Compare(this[parent], this[up]) <= 0)
                    {
                        break;
                    }
                    swap(parent, up);
                    up = parent;
                }
                if (up != position)
                    return;

                int down = position;
                while (down * 2 + 1 < Count)
                {
                    int child = down * 2 + 1;
                    if (child + 1 < Count &&
                      comparer.Compare(this[child + 1], this[child]) <= 0)
                        child++;

                    if (comparer.Compare(this[down], this[child]) <= 0)
                        break;

                    swap(child, down);
                    down = child;
                }

            }

            private void swap(int a, int b)
            {
                T temp = this[a];
                this[a] = this[b];
                this[b] = temp;
            }

            public void Enqueue(T item)
            {
                Add(item);
                AdjustHeap(Count - 1);
            }
            public T Dequeue()
            {
                int last = Count - 1;
                swap(0, last);
                T res = this[last];

                this.RemoveAt(last);
                AdjustHeap(0);

                return res;
            }
        }
    }
}
