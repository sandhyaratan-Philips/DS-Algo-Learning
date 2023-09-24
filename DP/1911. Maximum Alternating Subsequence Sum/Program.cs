internal class Program
{
    int[] arr;int n; long[][] memo;
    public long MaxAlternatingSum(int[] nums)
    {
        memo=new long[100001][];
        for (int i=0; i<nums.Length; i++)
        {
            memo[i]=new long[2];
            Array.Fill(memo[i],-1);
        }
        arr = nums;
        n= arr.Length;
        return solve(0,true);
    }

    private long solve(int idx,bool flag)
    {
        if(idx>=n)
            return 0;
        if (memo[idx][Convert.ToInt32(flag)] != -1)
        {
            return memo[idx][Convert.ToInt32(flag)];
        }
        long skip=solve(idx+1,flag);
        int val = arr[idx];
        if (!flag)
            val *= -1;
              
        long take=solve(idx+1,!flag)+val;
        return memo[idx][Convert.ToInt32(flag)] =Math.Max(skip, take);
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.MaxAlternatingSum(new int[] { 5, 6, 7, 8 }));
    }
}