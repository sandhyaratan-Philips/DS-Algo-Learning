using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        LinkedList<T> list = new LinkedList<T>();
        public Queue()
        {

        }
        public Queue(T elem)
        {
            list.AddLast(elem);
        }

        public int size()
        {
            return list.Count;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public T peek()
        {
            if (isEmpty())
                throw new ArgumentNullException("Queue empty");
            return list.First.Value;
        }

        public T poll()
        {
            if (isEmpty())
                throw new ArgumentNullException("Queue empty");

            var data = list.First.Value;
            list.RemoveFirst();
            return data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
