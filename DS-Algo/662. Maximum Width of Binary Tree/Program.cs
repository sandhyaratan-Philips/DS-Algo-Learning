using System;
using System.Collections.Generic;

namespace _662._Maximum_Width_of_Binary_Tree
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
        Dictionary<int, int> left = null;
        int ans = 0;
        public int WidthOfBinaryTree(TreeNode root)
        {
            ans = 0;
            left = new Dictionary<int, int>();
            dfs(root, 0, 0);
            return ans;
        }
        public void dfs(TreeNode root, int depth, int pos)
        {
            if (root == null) return;
            if (!left.ContainsKey(depth))
            {
                left.Add(depth, pos);
            }
            ans = Math.Max(ans, pos - left[depth] + 1);
            dfs(root.left, depth + 1, 2 * pos);
            dfs(root.right, depth + 1, 2 * pos + 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
