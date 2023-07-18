using System;
using System.Collections.Generic;

namespace _863._All_Nodes_Distance_K_in_Binary_Tree_with_bfs
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
        Dictionary<TreeNode, TreeNode> adj;
        HashSet<int> visited;
        List<int> res;

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            if (root == null)
                return null;
            adj = new Dictionary<TreeNode, TreeNode>();
            inorderAdj(root);
            res = new List<int>();
            BFS(target, k);


            return res;
        }

        private void BFS(TreeNode target, int k)
        {
            visited = new HashSet<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            visited.Add(target.val);
            q.Enqueue(target);
            while (q.Count > 0)
            {
                if (k == 0)
                    break;
                int n = q.Count;
                while (n-- > 0)
                {
                    var curr = q.Dequeue();
                    if (curr.left != null && !visited.Contains(curr.left.val))
                    {
                        q.Enqueue(curr.left);
                        visited.Add(curr.left.val);
                    }
                    if (curr.right != null && !visited.Contains(curr.right.val))
                    {
                        q.Enqueue(curr.right);
                        visited.Add(curr.right.val);
                    }
                    if (adj.ContainsKey(curr) && adj[curr] != null && !visited.Contains(adj[curr].val))
                    {
                        q.Enqueue(adj[curr]);
                        visited.Add(adj[curr].val);
                    }
                }
                k--;

            }

            while (q.Count > 0)
            {
                res.Add(q.Dequeue().val);
            }
        }

        private void inorderAdj(TreeNode root)
        {
            if (root == null)
                return;
            if (root.left != null)
            {
                adj.Add(root.left, root);
            }
            inorderAdj(root.left);

            if (root.right != null)
            {
                adj.Add(root.right, root);
            }
            inorderAdj(root.right);
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
