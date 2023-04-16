using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    public class Node<T>
    {
        public T data;
        public Node<T> prev, next;
        public Node(T data, Node<T> pre, Node<T> next)
        {
            this.data = data;
            this.prev = pre;
            this.next = next;
        }
        public string toString() => data.ToString();
    }
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;
        private int count = 0;
        public void clear()
        {
            Node<T> trav = head;

            while (trav != null)
            {
                Node<T> next = trav.next;
                trav.prev = trav.next = null;
                trav.data = default;
                trav = next;
            }
            head = tail = null;
            count = 0;
        }

        public int size()
        {
            return count;
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public void add(T element)
        {
            addLast(element);
        }

        public void addFirst(T element)
        {
            if (isEmpty())
            {
                head = tail = new Node<T>(element, null, null);
            }
            else
            {
                head.prev = new Node<T>(element, null, head);
                head = head.prev;
            }
            count++;
        }

        public void addLast(T element)
        {
            if (isEmpty())
            {
                head = tail = new Node<T>(element, null, null);
            }
            else
            {
                tail.next = new Node<T>(element, tail, null);
                tail = tail.next;
            }
            count++;
        }

        public T peekFirst()
        {
            if (isEmpty()) throw new ArgumentNullException("empty list");
            return head.data;
        }

        public T peekLast()
        {
            if (isEmpty()) throw new ArgumentNullException("empty list");
            return tail.data;
        }

        public T removeFirst()
        {
            if (isEmpty()) throw new ArgumentNullException("empty list");

            T data = head.data;
            head = head.next;
            --count;

            if (isEmpty()) tail = null;
            else head.prev = null;
            return data;
        }

        public T removeLast()
        {
            if (isEmpty()) throw new ArgumentNullException("empty list");

            T data = tail.data;
            tail = tail.prev;
            --count;

            if (isEmpty()) head = null;
            else tail.next = null;
            return data;
        }

        public T removeAt(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException();

            Node<T> trav;

            if (index < count / 2)
            {
                trav = head;
                for (int i = 0; i != index; i++)
                {
                    trav = trav.next;
                }
            }
            else
            {
                trav = tail;
                for (int i = count - 1; i != index; i++)
                {
                    trav = trav.prev;
                }
            }
            return remove(trav);
        }

        private T remove(Node<T> node)
        {
            if (node.prev == null) return removeFirst();
            if (node.next == null) return removeLast();

            node.next.prev = node.prev;
            node.prev.next = node.next;

            T data = node.data;
            node.data = default;
            node = node.next = node.prev = null;
            count--;
            return data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
