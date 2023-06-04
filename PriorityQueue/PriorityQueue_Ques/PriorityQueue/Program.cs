using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    class MyComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            // "inverted" comparison
            // direct comparison of integers should return x - y
            return x - y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> q = new PriorityQueue<int>(new MyComparer());
            q.Enqueue(4);
            q.Enqueue(6);
            q.Enqueue(-1);
            q.Enqueue(0);


            Console.WriteLine("Hello World!");
        }
    }
}
