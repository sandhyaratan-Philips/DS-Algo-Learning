using System;

namespace _1601._Maximum_Number_of_Achievable_Transfer_Requests
{
    class Program
    {
        int result = 0;
        public int MaximumRequests(int n, int[][] requests)
        {
            int[] indegree = new int[n];
            solve(indegree, requests, n, 0, 0);
            return result;
        }

        private void solve(int[] indegree, int[][] requests, int n, int index, int countOfRequest)
        {
            if (index == requests.Length)
            {
                for (int i = 0; i < n; i++)
                {
                    if (indegree[i] != 0)
                        return;
                }
                result = Math.Max(result, countOfRequest);
                return;
            }

            indegree[requests[index][0]]--;
            indegree[requests[index][1]]++;

            solve(indegree, requests, n, index + 1, countOfRequest + 1);

            //reset back
            indegree[requests[index][0]]++;
            indegree[requests[index][1]]--;

            solve(indegree, requests, n, index + 1, countOfRequest);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MaximumRequests(4, new int[][] { new int[] { 0, 3 }, new int[] { 3, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } }));
            Console.WriteLine("Hello World!");
        }
    }
}
