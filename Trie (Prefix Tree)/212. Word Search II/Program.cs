using System;
using System.Collections.Generic;

namespace _212._Word_Search_II
{
    class Program
    {
        int m, n;
        List<string> result;
        public class trieNode
        {
            public bool isEndOfWord;
            public string word;
            public trieNode[] children;
        };
        trieNode GetNode()
        {

            trieNode newNode = new trieNode();
            newNode.isEndOfWord = false;
            newNode.word = "";
            newNode.children = new trieNode[26];
            for (int i = 0; i < 26; i++)
            {
                newNode.children[i] = null;
            }

            return newNode;
        }

        public void Insert(
            trieNode root, string word)
        {
            trieNode crawl = root;

            for (int i = 0; i < word.Length; i++)
            {
                int idx = word[i] - 'a';


                if (crawl.children[idx] == null)
                    crawl.children[idx] = GetNode();
                crawl = crawl.children[idx];
            }
            crawl.isEndOfWord = true;
            crawl.word = word;
        }
        public IList<string> FindWords(char[][] board, string[] words)
        {
            m = board.Length;
            n = board[0].Length;
            result = new List<string>();

            trieNode root = GetNode();

            foreach (var w in words)
            {
                Insert(root, w);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char ch = board[i][j];

                    if (root.children[ch - 'a'] != null)
                    {
                        FindWords(board, i, j, root);
                    }

                }
            }

            return result;
        }

        List<List<int>> direction = new List<List<int>> { new List<int> { 1, 0 }, new List<int> { -1, 0 }, new List<int> { 0, 1 }, new List<int> { 0, -1 } };

        private void FindWords(char[][] board, int i, int j, trieNode root)
        {
            if (i < 0 || i >= m || j < 0 || j >= n)
            {
                return;
            }
            if (board[i][j] == '$' || root.children[board[i][j] - 'a'] == null)
                return;

            root = root.children[board[i][j] - 'a'];
            if (root.isEndOfWord == true)
            {
                result.Add(root.word);
                root.isEndOfWord = false;
            }

            char temp = board[i][j];
            board[i][j] = '$';

            foreach (var dir in direction)
            {
                int new_i = i + dir[0];
                int new_j = j + dir[1];

                FindWords(board, new_i, new_j, root);

            }
            board[i][j] = temp;

        }

        //Input: board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]], words = ["oath","pea","eat","rain"]
        //Output: ["eat","oath"]
        static void Main(string[] args)
        {
            Program program = new Program();

            program.FindWords(new char[][] { new char[] { 'o', 'a', 'a', 'n' }, new char[] { 'e', 't', 'a', 'e' }, new char[] { 'i', 'h', 'k', 'r' }, new char[] { 'i', 'f', 'l', 'v' } }, new string[] { "oath", "pea", "eat", "rain" });
            Console.WriteLine("Hello World!");
        }
    }
}
