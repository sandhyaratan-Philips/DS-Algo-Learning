internal class Program
{
    IList<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> Permute(int[] nums)
    {
        List<int> temp = new List<int>();
        solve( nums,temp);
        return result;
    }

    private void solve(int[] nums,List<int> temp)
    {
        if(temp.Count==nums.Length)
        {
            result.Add(new List<int>(temp));
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (temp.Contains(nums[i]))
                continue;
            temp.Add(nums[i]);
            solve(nums, temp);
            temp.Remove(nums[i]);
        }
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        program.Permute(new int[] { 1, 0 });
        Console.WriteLine("Hello, World!");
    }
}