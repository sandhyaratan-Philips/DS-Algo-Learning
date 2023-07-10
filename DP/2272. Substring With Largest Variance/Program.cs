using System;

namespace _2272._Substring_With_Largest_Variance
{
    class Program
    {
        public int LargestVariance(string s)
        {
            int[] charCount = new int[26];

            foreach (var item in s)
            {
                charCount[item - 'a']++;
            }
            int res = 0;
            for (char F1 = 'a'; F1 <= 'z'; F1++)
            {
                for (char F2 = 'a'; F2 <= 'z'; F2++)
                {
                    if (charCount[F1 - 'a'] == 0 || charCount[F2 - 'a'] == 0)
                    {
                        continue;
                    }
                    int firstCount = 0;//f1
                    int secondCount = 0;//f2
                    bool pastSecond = false;
                    foreach (var ch in s)
                    {
                        if (ch == F1)
                            firstCount++;
                        if (ch == F2)
                            secondCount++;

                        if (secondCount > 0)
                            res = Math.Max(res, firstCount - secondCount);
                        else if (pastSecond == true)
                            res = Math.Max(res, firstCount - 1);

                        if (secondCount > firstCount)
                        {
                            secondCount = 0;
                            firstCount = 0;
                            pastSecond = true;
                        }

                    }
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
