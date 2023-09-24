using System;

internal class Program
{
    public int MinimizeArrayValue(int[] nums)
    {
        long answer = 0, prefixSum = 0;

        for (int i = 0; i < nums.Length; ++i)
        {
            prefixSum += nums[i];
            answer = Math.Max(answer, (prefixSum + i) / (i + 1));
        }

        return (int)answer;
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.MinimizeArrayValue(new int[] { 13, 13, 20, 0, 8, 9, 9}));
        //Console.WriteLine(program.MinimizeArrayValue(new int[] { 10,0}));
        //Console.WriteLine(program.MinimizeArrayValue(new int[] { 3,7,1,6}));
    }
}