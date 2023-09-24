internal class Program
{
    public int PeakIndexInMountainArray(int[] arr)
    {
        //approch 1
        //int i = 0;
        //for (i = 1; i < arr.Length; i++)
        //{
        //    if (arr[i] < arr[i - 1])
        //        break;
        //}
        //return i-1;

        int l = 0;
        int r=arr.Length;

        while (l < r)
        {
            int mid= (l+r)/2;

            if (arr[mid] < arr[mid+1])
                l = mid+1;
            else
                r = mid - 1;


        }
        return l;

    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.PeakIndexInMountainArray(new int[] { 0, 10, 5, 2 }));
    }
}