internal class Program
{
    bool isFeasible(List<int> pos,int mid, int k,int n)
    {
        int position = pos[0];
        int count = 1;
        for(int i = 1; i < n; i++)
        {
            if (pos[i]-position>= mid)
            {
                count++;
                position = pos[i];
                if(count==k)
                    return true;
            }
        }
        return false;
    }
    int largestMinDist(List<int> pos, int k)
    {
        int n = pos.Count;
        int l = pos[0];
        int r = pos[n-1];
        int res = -1;

        while (l < r)
        {
            int mid= (l+r)/2;
            if (isFeasible(pos,mid, k, n))
            {
                res = mid;
                l = mid + 1;
            }
            else
                r=mid;
        }
        return res;
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.largestMinDist(new List<int>{ 1, 2, 7, 5, 11, 12 },3));
    }
}