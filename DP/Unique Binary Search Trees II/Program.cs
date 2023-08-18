using System.Collections.Generic;

internal class Program
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
    public List<TreeNode> allPossibleBST(int start, int end,
           Dictionary<KeyValuePair<int, int>, List<TreeNode>> memo)
    {
        List<TreeNode> res = new List<TreeNode>();
        if (start > end)
        {
            res.Add(null);
            return res;
        }

        if (start == end)
        {
            res.Add(new TreeNode(start));
            return res;
        }

        if (memo.ContainsKey(new KeyValuePair<int, int>(start, end)))
        {
            return memo[new KeyValuePair<int, int>(start, end)];
        }
        for (int i = start; i <= end; ++i)
        {
            List<TreeNode> leftSubTrees = allPossibleBST(start, i - 1, memo);
            List<TreeNode> rightSubTrees = allPossibleBST(i + 1, end, memo);

            foreach (TreeNode left in leftSubTrees)
            {
                foreach (TreeNode right in rightSubTrees)
                {
                    TreeNode root = new TreeNode(i, left, right);
                    res.Add(root);
                }
            }
        }
        memo.Add(new KeyValuePair<int, int>(start, end), res);
        return res;
    }

    public List<TreeNode> GenerateTrees(int n)
    {
        Dictionary<KeyValuePair<int, int>, List<TreeNode>> memo = new Dictionary<KeyValuePair<int, int>, List<TreeNode>>();
        return allPossibleBST(1, n, memo);
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        program.GenerateTrees(3);
        Console.WriteLine("Hello, World!");
    }
}