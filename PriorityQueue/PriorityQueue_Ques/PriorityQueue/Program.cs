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
            return y - x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int, string> q = new PriorityQueue<int, string>
            (data, new MyComparer());
            Console.WriteLine("Hello World!");
        }
    }
}
