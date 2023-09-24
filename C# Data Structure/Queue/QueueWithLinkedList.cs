using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Node
    {
        public int data { get; set; }
        public Node node { get; set; }
        public Node(int data)
        {
            this.data = data;
            this.node = null;
        }
    }
    public class QueueWithLinkedList
    {
        private Node front;
        private Node rear;

        public QueueWithLinkedList()
        {
            front = null;
            rear = null;
        }
        public int size()
        {
            int size = 0;
            Node p = front;
            while (p != null)
            {
                size++;
                p = p.node;
            }
            return size;
        }

        public void insert(int x)
        {
            Node temp = new Node(x);
            if (front == null)
                front = temp;
            else
            {
                rear.node = temp;
            }
            rear = temp;
        }

        private int delete()
        {
            int x;
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue underflow");
            }
            x = front.data;
            front = front.node;
            return x;
        }
        private int Peek()
        {

            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue underflow");
            }
            return front.data;
        }


        private bool IsEmpty()
        {
            return front == null;
        }
    }
}
