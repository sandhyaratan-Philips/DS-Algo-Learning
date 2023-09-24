
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public int _data { get; set; }
        public Node _node { get; set; }
        public Node(int data)
        {
            _data = data;
            _node = null;
        }
    }
    public class SingleLinkedList
    {

       public Node _start;
        public SingleLinkedList()
        {
            _start = null;
        }

        public void createList(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                InsertAtEnd(i);
            }
        }

        public void DisplayNode()
        {
            Node P;
            if( _start == null )
            {
                Console.WriteLine("List is empty");
                return;
            }
            P=_start;
            while ( P != null ) {
                Console.WriteLine(P._data);
                P=P._node;
            }
        }


        public int CountNode()
        {
            Node P;
            int count = 0;
            if (_start == null)
            {
                Console.WriteLine("List is empty");
                return 0;
            }
            P = _start;
            while (P != null)
            {
                P = P._node;
                count++;
            }
            return count;
        }

        public bool Search(int x)
        {
            Node P;
            if (_start == null)
            {
                Console.WriteLine("List is empty");
                return false;
            }
            P = _start;
            while (P != null)
            {
                if(P._data==x)
                {
                    return true;
                }
               P = P._node;
            }
            return false;
        }

        public void InsertAtStart(int x)
        {
            Node temp = new Node(x);
            temp._node = _start;
            _start=temp;   
        }

        public void InsertAtEnd(int x)
        {
            if(_start == null)
            {
                _start = new Node(x);
                return;
            }
            Node P = _start;
            while (P._node != null)
            {
                P = P._node;
            }
            Node temp = new Node(x);
            P._node = temp;
        }

        public void InsertAfter(int data,int xData)
        {
            Node P;
            if (_start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            P = _start;

            while (P._node != null)
            {
                if(P._data== xData)
                {
                    break;
                }
                P = P._node;
            }
            Node temp= new Node(data);
            temp._node = P._node;
            P._node = temp;
        }

        public void InsertBefore(int data, int xData)
        {
            Node P;
            if (_start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            P = _start;

            while (P._node != null)
            {
                if (P._node._data == xData)
                {
                    break;
                }
                P = P._node;
            }
            Node temp = new Node(data);
            temp._node = P._node;
            P._node = temp;
        }

        public void DeleteNode(int data)
        {
            Node P;
            if (_start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            P = _start;

            while (P._node != null)
            {
                if (P._node._data == data)
                {
                    break;
                }
                P = P._node;
            }
            P._node = P._node._node;
        }

        public void InsertAt(int data, int position)
        {
            Node P; Node temp;
            if (position == 1)
            {
               temp =new Node(data);
                temp._node=_start._node;
                _start=temp;
                return;
            }
            P = _start;
            for (int i = 0; i < position-1 && P!=null ; i++)
            {
                P = P._node;
            }
            temp = new Node(data);
            temp._node = P._node;
            P = temp;
        }

        public void Reverse()
        {
            Node prev=null, p, next;

            p = _start;

            while( p != null )
            {
                next=p._node;
                p._node = prev;
                prev = p;
                p = next;
            }
            _start = prev;
        }

    }
}
