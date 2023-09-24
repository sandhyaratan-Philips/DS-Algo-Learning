using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueWithCircularLinkedLst
    {
        private Node rear;

        public QueueWithCircularLinkedLst()
        {
            rear = null;
        }
        public int size()
        {
            if(IsEmpty()) return 0;
            int size = 0;
            Node p = rear.node;
            do
            {
                size++;
                p = p.node;
            }while (p != rear.node);
            return size;
        }

        public void insert(int x)
        {
            Node temp = new Node(x);
            if (rear == null)
            {
                rear = temp;
                rear.node = temp;
            }
            else
            {
                temp.node = rear;
                rear.node = temp;
                rear= temp;
            }
            rear = temp;
        }

        private int delete()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue underflow");
            }
            Node temp;
            if (rear.node == rear)
            {
                temp=rear;
                rear = null;
            }
            else
            {
                temp = rear.node;
                rear.node = temp.node;
            }

            return temp.data;
        }
        private int Peek()
        { 
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue underflow");
            }
            return rear.node.data;
        }


        private bool IsEmpty()
        {
            return rear == null;
        }
    }
}
