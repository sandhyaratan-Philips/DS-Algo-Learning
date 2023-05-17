using System;

namespace _24._Swap_Nodes_in_Pairs
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Program
    {
        public ListNode SwapPairs(ListNode head)
        {
            ListNode dummy = new ListNode(-1);
            dummy.next = head;

            ListNode prevNode = dummy;

            while ((head != null) && (head.next != null))
            {

                ListNode firstNode = head;
                ListNode secondNode = head.next;

                prevNode.next = secondNode;
                firstNode.next = secondNode.next;
                secondNode.next = firstNode;

                prevNode = firstNode;
                head = firstNode.next;
            }

            return dummy.next;

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            program.SwapPairs(head);
            Console.WriteLine("Hello World!");
        }
    }
}
