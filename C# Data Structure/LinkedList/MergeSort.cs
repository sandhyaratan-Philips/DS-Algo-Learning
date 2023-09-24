using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class MergeSort
    {
        public void MergeSortLst()
        {
            SingleLinkedList singleLinkedList = new SingleLinkedList();
            singleLinkedList._start = MergeSortLst(singleLinkedList._start);
        }

        private Node MergeSortLst(Node lstStart)
        {
            if (lstStart == null || lstStart._node == null)
                return lstStart;

            Node start1 = lstStart;
            Node start2 =DivideList(lstStart);
            start1=MergeSortLst(start1);
            start2=MergeSortLst(start2);

            Node startM= MergeWithoutExtraMemory(start1,start2);
            return startM;
        }

        private Node DivideList(Node p)
        {
            Node q = p._node._node;
            while (q != null && q._node!=null)
            {
                p = p._node;
                q = q._node._node;
            }
            Node start2=p._node;
            p._node=null;
            return start2;
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
                    pM._node = p1;
                    p1 = p1._node;
                }
                else
                {
                    pM._node = p2;
                    p2 = p2._node;
                }
                pM = pM._node;
            }
            if (p1 != null)
            {
                pM._node = p1;
            }
            while (p2 != null)
            {
                pM._node = p2;
            }
            return start;
        }
    }
}
