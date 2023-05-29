using System;

namespace _208._Implement_Trie__Prefix_Tree_
{
    class Program
    {
        //Input
        //["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
        //[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
        //Output
        //[null, null, true, false, true, null, true]

        public class trieNode
        {
            public bool isEndOfWord;
            public trieNode[] children;
        };
        trieNode GetNode()
        {

            trieNode newNode = new trieNode();
            newNode.isEndOfWord = false;
            newNode.children = new trieNode[26];
            for (int i = 0; i < 26; i++)
            {
                newNode.children[i] = null;
            }

            return newNode;
        }

        trieNode root;

        public Program()
        {
            root = GetNode();
        }

        public void Insert(string word)
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

        }

        public bool Search(string word)
        {
            trieNode crawl = root;

            for (int i = 0; i < word.Length; i++)
            {
                int idx = word[i] - 'a';


                if (crawl.children[idx] == null)
                    return false;
                crawl = crawl.children[idx];
            }

            if (crawl != null && crawl.isEndOfWord == true)
                return true;

            return false;
        }

        public bool StartsWith(string prefix)
        {
            trieNode crawl = root;
            int i = 0;
            for (i = 0; i < prefix.Length; i++)
            {
                int idx = prefix[i] - 'a';


                if (crawl.children[idx] == null)
                    return false;
                crawl = crawl.children[idx];
            }

            if (i == prefix.Length)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Program trie = new Program();
            trie.Insert("apple");
            Console.WriteLine(trie.Search("apple"));   // return True
            Console.WriteLine(trie.Search("app"));     // return False
            Console.WriteLine(trie.StartsWith("app")); // return True
            trie.Insert("app");
            Console.WriteLine(trie.Search("app"));
            Console.WriteLine("Hello World!");
        }
    }
}
