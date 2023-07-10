using System;

namespace _111._Minimum_Depth_of_Binary_Tree
{
    class Program
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


        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            //bfs
            //Queue<TreeNode> q = new Queue<TreeNode>();
            //q.Enqueue(root);
            ////use below code for level or depth ques -> type of dfs
            //int depth = 1;
            //while (q.Count > 0)
            //{
            //    int n = q.Count;
            //    while (n-- > 0)//level at a time
            //    {
            //        TreeNode temp = q.Dequeue();
            //        if (temp.right == null && temp.left == null)
            //            return depth;
            //        if (temp.left != null)
            //            q.Enqueue(temp.left);
            //        if (temp.right != null)
            //            q.Enqueue(temp.right);
            //    }
            //    depth++;

            //}
            //return -1;

            //dfs
            if (root.right == null && root.left == null)
                return 1;

            int l = root.left != null ? MinDepth(root.left) : int.MaxValue;
            int r = root.right != null ? MinDepth(root.right) : int.MaxValue;
            return Math.Min(l, r) + 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
