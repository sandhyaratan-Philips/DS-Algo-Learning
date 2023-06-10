using System;

namespace _427._Construct_Quad_Tree
{
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }
    class Program
    {
        public Node Construct(int[][] grid)
        {
            return Solve(grid, 0, 0, grid.Length);
        }

        public Node Solve(int[][] grid, int x, int y, int n)
        {
            if (isAllValueSame(grid, x, y, n))
                return new Node(Convert.ToBoolean(grid[x][y]), true);
            else
            {
                Node root = new Node(true, false);
                root.topLeft = Solve(grid, x, y, n / 2);
                root.topRight = Solve(grid, x, y + n / 2, n / 2);
                root.bottomLeft = Solve(grid, x + n / 2, y, n / 2);
                root.bottomRight = Solve(grid, x + n / 2, y + n / 2, n / 2);
                return root;
            }
        }

        private bool isAllValueSame(int[][] grid, int x, int y, int n)
        {
            int val = grid[x][y];
            for (int i = x; i < x + n; i++)
            {
                for (int j = y; j < y + n; j++)
                {
                    if (val != grid[i][y]) return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Construct(new int[][] { new int[] { 1, 1, 1, 1, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 0, 0, 0, 0 })
            Console.WriteLine("Hello World!");
        }
    }
}
