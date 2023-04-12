using System;
using System.Collections.Generic;

namespace stack
{
    class Program
    {
        public Queue<int> q1 = new Queue<int>();
        public Queue<int> q2 = new Queue<int>();

        public void push(int data)
        {
            q2.Enqueue(data);
            while (q1.Count > 0)
            {
                q2.Enqueue(q1.Dequeue());
            }
            Queue<int> q = q1;
            q1 = q2;
            q2 = q;
        }
        public int peek()
        {
            if (q1.Count == 0)
                return -1;
            return q1.Peek();
        }

        public int pop()
        {
            if (q1.Count == 0)
                return -1;
            return q1.Dequeue();
        }
        public bool Empty()
        {
            return q1.Count == 0;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.push(1);
            program.push(2);
            program.push(3);
            var data = program.peek();
            data = program.pop();
            Console.WriteLine("Hello World!");
        }
    }
}
