internal class Program
{
    class TrieNode
    {
        public bool isWord { get; set; }

        public Dictionary<char, TrieNode> children;
        public TrieNode()
        {
            this.children = new Dictionary<char, TrieNode>();
        }
    }
    public bool WordBreak(string s, IList<string> wordDict)
    {
        TrieNode root=new TrieNode();
        foreach(string word in wordDict)
        {
            TrieNode curr=root;
            foreach(var c in word)
            {
                if (!curr.children.ContainsKey(c))
                {
                    curr.children.Add(c, new TrieNode());
                }
                curr= curr.children[c];
            }
            curr.isWord = true;
        }

        bool[] dp=new bool[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            if (i == 0 || dp[i - 1])
            {
                TrieNode curr=root;
                for (int j = i; j < s.Length; j++)
                {
                    if (!curr.children.ContainsKey(s[j]))
                    {
                        break;
                    }
                    curr= curr.children[s[j]];
                    if(curr.isWord)
                    {
                        dp[j] = true;
                    }
                }
            }
        }
        return dp[s.Length - 1];
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.WordBreak(s : "applepenapple", wordDict :new List<string>() { "apple", "pen" }));
    }
}