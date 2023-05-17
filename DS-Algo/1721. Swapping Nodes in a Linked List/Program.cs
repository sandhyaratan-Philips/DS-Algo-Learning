using System;

namespace _1721._Swapping_Nodes_in_a_Linked_List
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
        public ListNode SwapNodes(ListNode head, int k)
        {
            ListNode front = null;
            ListNode last = null;
            int count = 0;
            ListNode curr = head;

            while (curr != null)
            {
                count++;
                if (last != null)
                {
                    last = last.next;
                }
                if (count == k)
                {
                    front = curr;
                    last = head;
                }
                curr = curr.next;
            }
            int temp = front.val;
            front.val = last.val;
            last.val = temp;

            return head;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            program.SwapNodes(head, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
