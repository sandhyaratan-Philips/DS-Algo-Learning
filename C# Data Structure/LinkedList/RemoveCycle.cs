using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class RemoveCycle
    {
        //hare n tortoise algo
        SingleLinkedList singleLinkedList = new SingleLinkedList();
        public Node FindCycle()
        {
            if(singleLinkedList._start==null || singleLinkedList._start==null) return null;
            Node slow= singleLinkedList._start;
            Node fast = singleLinkedList._start;

            while(fast != null && fast._node==null)
            {
                slow=slow._node;
                fast = fast._node._node;
                if(slow==fast)
                    return slow;
            }
            return null;
        }
    }
}
