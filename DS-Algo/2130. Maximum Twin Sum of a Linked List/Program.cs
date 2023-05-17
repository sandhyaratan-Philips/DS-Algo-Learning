using System;

namespace _2130._Maximum_Twin_Sum_of_a_Linked_List
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


        public int PairSum(ListNode head)
        {
            int max = 0;
            ListNode slow = head;
            ListNode fast = head;

            // Let slow point to the start of the second half
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            ListNode last = reverse(slow);

            while (last != null)
            {
                max = Math.Max(max, head.val + last.val);
                head = head.next;
                last = last.next;
            }
            return max;
        }

        private ListNode reverse(ListNode curr)
        {
            ListNode prev = null;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            program.PairSum(head);
            Console.WriteLine("Hello World!");
        }
    }
}
