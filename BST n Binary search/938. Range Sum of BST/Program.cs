using System;

namespace _938._Range_Sum_of_BST
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
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            return inorder(root, low, high);
        }

        private int inorder(TreeNode root, int low, int high)
        {
            if (root == null)
                return 0;
            if (root.val >= low && root.val <= high)
                return root.val + inorder(root.left, low, high) + inorder(root.right, low, high);
            if (root.val < low)
                return inorder(root.right, low, high);
            if (root.val > high)
                return inorder(root.left, low, high);
            return 0;
        }

        // root = [10,5,15,3,7,null,18], low = 7, high = 15
        static void Main(string[] args)
        {
            Program program = new Program();
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(5, new TreeNode(3), new TreeNode(7));
            root.right = new TreeNode(15, null, new TreeNode(18));
            Console.WriteLine(program.RangeSumBST(root, 7, 15));
            Console.WriteLine("Hello World!");
        }
    }
}
