using System;
using System.Collections.Generic;

namespace _1161._Maximum_Level_Sum_of_a_Binary_Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        public int MaxLevelSum(TreeNode root)
        {
            int maxSum = int.MaxValue;
            int resLevel = 0;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            int currLevel = 1;

            while (q.Count > 0)
            {
                int n = q.Count;
                int sum = 0;

                while (n-- > 0)
                {
                    var temp = q.Dequeue();

                    sum += temp.val;
                    if (temp.left != null)
                        q.Enqueue(temp.left);

                    if (temp.right != null)
                        q.Enqueue(temp.right);
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    resLevel = currLevel;
                }
                currLevel++;
            }
            return resLevel;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
