using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class MergeSortedList
    {
        public SingleLinkedList MergeWithExtraMemory(SingleLinkedList list1,SingleLinkedList list2)
        {
            SingleLinkedList lst = new SingleLinkedList();
            //lst._start= MergeWithExtraMemory(list1._start, list2._start);
            lst._start= MergeWithoutExtraMemory(list1._start, list2._start);
            return lst;
        }

        public Node MergeWithoutExtraMemory(Node p1, Node p2)
        {
            Node start;

            if (p1._data < p2._data)
            {
                start = p1;
                p1 = p1._node;
            }
            else
            {
                start = p2;
                p2 = p2._node;
            }
            Node pM = start;
            while (p1 != null && p2 != null)
            {
                if (p1._data <= p2._data)
                {
                    pM._node =p1;
                    p1 = p1._node;
                }
                else
                {
                    pM._node = p2;
                    p2=p2._node;
                }
                pM = pM._node;
            }
            if(p1 != null)
            {
                pM._node = p1;
            }
            while (p2 != null)
            {
                pM._node = p2;
            }
            return start;
        }

        private Node MergeWithExtraMemory(Node p1, Node p2)
        {
            Node start;

            if (p1._data < p2._data)
            {
                start = new Node(p1._data);
            }
            else
            {
                start = new Node(p2._data);
            }

            Node pM = start;
            while (p1 != null && p2!=null)
            {
                if (p1._data < p2._data)
                {
                    pM._node = new Node(p1._data);
                    p1=p1._node;
                }
                else
                {
                    pM._node = new Node(p2._data);
                    p2=p2._node;
                }
                pM=pM._node;
            }
            while (p1 != null )
            {
                pM._node = new Node(p1._data);
                p1 = p1._node;
                pM = pM._node;
            }
            while (p2 != null)
            {
                pM._node = new Node(p2._data);
                p1 = p2._node;
                pM = pM._node;
            }
            return start;
        }
    }
}
