using System;
using System.Collections.Generic;

namespace _131._Palindrome_Partitioning
{
    class Program
    {
        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> ans = new List<IList<string>>();
            backTracking(s, 0, new List<string>(), ans);
            return ans;
        }

        private void backTracking(string s, int start, List<string> path, List<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(path));
                return;
            }

            for (int i = start; i < s.Length; ++i)
                if (isPalindrome(s, start, i))
                {
                    path.Add(s.Substring(start, i - start + 1));
                    backTracking(s, i + 1, path, result);
                    path.RemoveAt(path.Count - 1);
                }
        }

        private bool isPalindrome(String s, int l, int r)
        {
            while (l < r)
                if (s[l++] != s[r--])
                    return false;
            return true;
        }

        //Input: s = "aab"
        //Output: [["a","a","b"],["aa","b"]]
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.Partition("cbbbcc"));
            // Console.WriteLine(program.Partition("aab"));
        }
    }
}
