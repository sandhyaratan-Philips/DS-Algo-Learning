using System;
using System.Collections.Generic;
using System.Linq;

namespace _863._All_Nodes_Distance_K_in_Binary_Tree
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        Dictionary<int, List<int>> adj;
        HashSet<int> visited;
        IList<int> res;

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            if (root == null)
                return null;
            adj = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();
            CreateAdjList(root, null);
            res = new List<int>();
            visited.Add(target.val);
            dfs(target.val, 0, k);
            return res;

        }

        private void dfs(int currVal, int distance, int k)
        {
            if (distance == k)
            {
                res.Add(currVal);
                return;
            }
            var data = adj.Where(x => x.Key == currVal).FirstOrDefault().Value ?? new List<int>();

            foreach (var curr in data)
            {
                if (!visited.Contains(curr))
                {
                    visited.Add(curr);
                    dfs(curr, distance + 1, k);
                }
            }
        }

        public void CreateAdjList(TreeNode current, TreeNode Parent)
        {
            if (current != null && Parent != null)
            {
                if (adj.ContainsKey(current.val))
                    adj[current.val].Add(Parent.val);
                else
                    adj.Add(current.val, new List<int>() { Parent.val });
                if (adj.ContainsKey(Parent.val))
                    adj[Parent.val].Add(current.val);
                else
                    adj.Add(Parent.val, new List<int>() { current.val });
            }
            if (current.left != null)
            {
                CreateAdjList(current.left, current);
            }
            if (current.right != null)
            {
                CreateAdjList(current.right, current);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            TreeNode root = new TreeNode(3);
            root.right = new TreeNode(1);
            root.left = new TreeNode(5);
            program.DistanceK(root, root.left, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
