using System;

namespace _21._Merge_Two_Sorted_Lists
{
    //Input: list1 = [1,2,4], list2 = [1,3,4]
    //Output: [1,1,2,3,4,4]
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
        //public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        //{
        //    if (list1 == null) return list2;
        //    if (list2 == null) return list1;

        //    if (list1.val > list2.val)
        //    {
        //        list2.next = MergeTwoLists(list1, list2.next);
        //        return list2;
        //    }
        //    else
        //    {
        //        list1.next = MergeTwoLists(list2, list1.next);
        //        return list1;
        //    }
        //}


        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode();
            ListNode tail = dummy;
            while (list1 != null && list2 != null)
            {
                if (list1.val > list2.val)
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                else
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                tail = tail.next;
            }

            if (list1 != null)
                tail.next = list1;

            if (list2 != null)
                tail.next = list2;

            return dummy.next;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            ListNode root1 = new ListNode(1, new ListNode(2, new ListNode(4, null)));
            ListNode root2 = new ListNode(1, new ListNode(3, new ListNode(4, null)));

            ListNode root = program.MergeTwoLists(root1, root2);
            Console.WriteLine("Hello World!");
        }
    }
}
