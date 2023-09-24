using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
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
    public class StackWithLinkedList
    {
        private Node top;
        public StackWithLinkedList()
        {
            top = null;
        }

        public int size()
        {
            int size = 0;
            Node p = top;
            while (p != null)
            {
                p=p.node;
                size++;
            }
        return size;
        }

        public void Push(int x)
        {
            Node temp=new Node(x);
            temp.node = top;
            top= temp;
        }

        public int Pop()
        {
            int x;
            if(IsEmpty())
                throw new InvalidOperationException("stack underflow");
            x = top.data;
            top = top.node;
            return x;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("stack is empty");
            return top.data;
        }

        private bool IsEmpty()
        {
            return top == null;
        }
    }
}
