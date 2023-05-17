using System;
using System.Collections.Generic;

namespace _212._Word_Search_II
{
    class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public String word;
    }

    class Program
    {

        public IList<string> FindWords(char[][] board, string[] words)
        {
            foreach (String word in words)
                insert(word);

            List<String> ans = new List<string>();

            for (int i = 0; i < board.Length; ++i)
                for (int j = 0; j < board[0].Length; ++j)
                    find(board, i, j, root, ans);

            return ans;
        }

        private TrieNode root = new TrieNode();

        private void insert(String word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int i = c - 'a';
                if (node.children[i] == null)
                    node.children[i] = new TrieNode();
                node = node.children[i];
            }
            node.word = word;
        }

        private void find(char[][] board, int i, int j, TrieNode node, List<String> ans)
        {
            if (i < 0 || i == board.Length || j < 0 || j == board[0].Length)
                return;
            if (board[i][j] == '*')
                return;

            char c = board[i][j];
            TrieNode child = node.children[c - 'a'];
            if (child == null)
                return;
            if (child.word != null)
            {
                ans.Add(child.word);
                child.word = null;
            }

            board[i][j] = '*';
            find(board, i + 1, j, child, ans);
            find(board, i - 1, j, child, ans);
            find(board, i, j + 1, child, ans);
            find(board, i, j - 1, child, ans);
            board[i][j] = c;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.FindWords(new char[][] { new char[] { 'o', 'a', 'a', 'n' }, new char[] { 'e', 't', 'a', 'e' }, new char[] { 'i', 'h', 'k', 'r' }, new char[] { 'i', 'f', 'l', 'v' } }, new string[] { "oath", "pea", "eat", "rain" }));
            Console.WriteLine(program.FindWords(new char[][] { new char[] { 'a', 'a' } }, new string[] { "aaa" }));
        }
    }
}
