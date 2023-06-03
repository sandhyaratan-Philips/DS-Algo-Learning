using System;
using System.Collections.Generic;

namespace _990._Satisfiability_of_Equality_Equations
{
    class Program
    {
        List<int> parent;
        List<int> rank;
        public bool EquationsPossible(string[] equations)
        {
            parent = new List<int>();
            rank = new List<int>();
            for (int i = 0; i < 26; i++)
            {
                rank.Add(0);
                parent.Add(i);
            }

            for (int i = 0; i < equations.Length; i++)
            {
                if (equations[i][1] == '=')
                    union(equations[i][0] - 'a', equations[i][3] - 'a');
            }

            for (int i = 0; i < equations.Length; i++)
            {
                if (equations[i][1] != '=')
                {
                    if (find(equations[i][0] - 'a') == find(equations[i][3] - 'a'))
                        return false;
                }
            }
            return true;
        }
        void union(int x, int y)
        {
            int x_parent = find(x);
            int y_parent = find(y);
            if (x_parent == y_parent)
            {
                return;
            }
            else if (rank[x_parent] > rank[y_parent])
            {
                parent[y_parent] = x_parent;
            }
            else if (rank[y_parent] > rank[x_parent])
            {
                parent[x_parent] = y_parent;
            }
            else
            {
                parent[x_parent] = y_parent;
                rank[y_parent]++;
            }
        }

        private int find(int x)
        {
            if (x == parent[x])
                return x;
            return parent[x] = find(parent[x]);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.EquationsPossible(new string[] { "c==c", "b==d", "x!=z" }));
            Console.WriteLine("Hello World!");
        }
    }
}
