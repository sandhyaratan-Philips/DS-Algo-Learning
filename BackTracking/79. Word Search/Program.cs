using System;
using System.Collections.Generic;

namespace _79._Word_Search
{
    class Program
    {
        private int n;
        private int m;
        private List<List<int>> direction = new List<List<int>> { new List<int> { 1, 0 }, new List<int> { -1, 0 }, new List<int> { 0, 1 }, new List<int> { 0, -1 } };

        //Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
        //Output: true
        public bool Exist(char[][] board, string word)
        {
            m = board.Length;
            n = board[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == word[0] && find(board, i, j, 0, word))
                        return true;
                }
            }
            return false;
        }

        private bool find(char[][] board, int i, int j, int idx, string word)
        {
            if (idx == word.Length)
                return true;
            if (i < 0 || j < 0 || i >= m || j >= n || board[i][j] == '$')
                return false;
            if (board[i][j] != word[idx]) return false;
            char temp = board[i][j];
            board[i][j] = '$';

            foreach (var dir in direction)
            {
                int new_i = i + dir[0];
                int new_j = j + dir[1];
                if (find(board, new_i, new_j, idx + 1, word))
                    return true;
            }

            board[i][j] = temp;
            return false;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.Exist(new char[][] { new char[] { 'A', 'B', 'C', 'E' }, new char[] { 'S', 'F', 'C', 'S' }, new char[] { 'A', 'D', 'I', 'E' } }, "SEE"));
        }
    }
}
