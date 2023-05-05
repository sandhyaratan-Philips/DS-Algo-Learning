using System;
using System.Collections.Generic;
using System.Linq;

namespace _1456_Maximum_Number_of_Vowels_in_a_Substring_of_Given_Length
{
    //    Input: s = "abciiidef", k = 3
    //    Output: 3
    //    Explanation: The substring "iii" contains 3 vowel letters.
    class Program
    {
        public static int MaxVowels(string s, int k)
        {
            int l = 0;
            int r = 0;
            int max = 0;
            int ans = 0;
            List<Char> vovel = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            foreach (var c in s)
            {
                if (r - l >= k)
                {
                    if (vovel.Any(e => e == s[l]))
                    {
                        max--;
                    }
                    l++;
                }
                if (vovel.Any(e => e == c))
                {
                    max++;
                }

                r++;
                ans = Math.Max(max, ans);
            }


            return ans;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MaxVowels("abciiidef", 3));
        }
    }
}
