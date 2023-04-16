using System;

namespace _1639._Number_of_Ways_to_Form_a_Target_String_Given_a_Dictionary
{
    //Input: words = ["acca","bbbb","caca"], target = "aba"
    //Output: 6
    //Explanation: There are 6 ways to form target.
    //"aba" -> index 0 ("acca"), index 1 ("bbbb"), index 3 ("caca")
    //"aba" -> index 0 ("acca"), index 2 ("bbbb"), index 3 ("caca")
    //"aba" -> index 0 ("acca"), index 1 ("bbbb"), index 3 ("acca")
    //"aba" -> index 0 ("acca"), index 2 ("bbbb"), index 3 ("acca")
    //"aba" -> index 1 ("caca"), index 2 ("bbbb"), index 3 ("acca")
    //"aba" -> index 1 ("caca"), index 2 ("bbbb"), index 3 ("caca")
    class Program
    {
        public int numWays(String[] words, String target)
        {
            int alphabets = 26;
            int mod = 1000000007;
            int m = target.Length, k = words[0].Length;
            var cnt = new int[alphabets, k];
            for (int j = 0; j < k; j++)
            {
                foreach (String word in words)
                {
                    cnt[word[j] - 'a', j]++;
                }
            }
            var dp = new long[m + 1, k + 1];
            dp[0, 0] = 1;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (i < m)
                    {
                        dp[i + 1, j + 1] += cnt[target[i] - 'a', j] * dp[i, j];
                        dp[i + 1, j + 1] %= mod;
                    }
                    dp[i, j + 1] += dp[i, j];
                    dp[i, j + 1] %= mod;
                }
            }
            return (int)dp[m, k];
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
