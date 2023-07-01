using System;
using System.Collections.Generic;

namespace _864._Shortest_Path_to_Get_All_Keys
{
    class Program
    {
        //'.' is an empty cell.
        //'#' is a wall.
        //'@' is the starting point.
        //Lowercase letters represent keys.
        //Uppercase letters represent locks.

        class visit
        {
            public int i { get; set; }
            public int j { get; set; }
            public int keyState { get; set; }
            public int steps { get; set; }
            public visit(int i, int j, int keyState, int step)
            {
                this.i = i;
                this.j = j;
                this.keyState = keyState;
                this.steps = step;
            }
        }

        List<List<int>> directions = new List<List<int>> {
        new List<int>{-1,0},
        new List<int>{1,0},
        new List<int>{0,-1},
        new List<int>{0,1}
        };
        public int ShortestPathAllKeys(string[] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int keyCount = 0;
            Queue<visit> q = new Queue<visit>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        q.Enqueue(new visit(i, j, 0, 0));
                    }
                    else
                    if (grid[i][j] >= 'a' && grid[i][j] <= 'f')
                    {
                        keyCount++;
                    }
                }
            }

            int finalKeyStatus = (int)(Math.Pow(2, keyCount) - 1);
            int[,,] visited = new int[m, n, finalKeyStatus + 1];

            while (q.Count > 0)
            {
                visit temp = q.Dequeue();

                if (temp.keyState == finalKeyStatus)
                    return temp.steps;

                foreach (var dir in directions)
                {
                    int new_i = temp.i + dir[0];
                    int new_j = temp.j + dir[1];

                    if (new_i >= 0 && new_i < m && new_j >= 0 && new_j < n && grid[new_i][new_j] != '#')
                    {
                        char ch = grid[new_i][new_j];

                        if (ch >= 'A' && ch <= 'F')//lock
                        {
                            if (visited[new_i, new_j, temp.keyState] == 0 && ((temp.keyState >> (ch - 'A')) & 1) == 1)//have key for the lock
                            {
                                visited[new_i, new_j, temp.keyState] = 1;
                                q.Enqueue(new visit(new_i, new_j, temp.keyState, temp.steps + 1));
                            }
                        }
                        else if (ch >= 'a' && ch <= 'f')//key
                        {
                            int newKeyStatusInDecimal = temp.keyState | 1 << (ch - 'a');
                            if (visited[new_i, new_j, newKeyStatusInDecimal] == 0)//have key for the lock
                            {
                                visited[new_i, new_j, newKeyStatusInDecimal] = 1;
                                q.Enqueue(new visit(new_i, new_j, newKeyStatusInDecimal, temp.steps + 1));
                            }
                        }
                        else
                        {
                            if (visited[new_i, new_j, temp.keyState] == 0)
                            {
                                visited[new_i, new_j, temp.keyState] = 1;
                                q.Enqueue(new visit(new_i, new_j, temp.keyState, temp.steps + 1));
                            }
                        }

                    }
                }
            }



            return -1;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ShortestPathAllKeys(new string[] { "@..aA", "..B#.", "....b" }));
            Console.WriteLine("Hello World!");
        }
    }
}
