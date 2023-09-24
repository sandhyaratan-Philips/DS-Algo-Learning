internal class Program
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int l = 1;
        int r = piles.Max();

        while (l < r)
        {
            int mid= (l+r)/2;
            if (canEatBanana(piles, mid, h))
            {
                r=mid;
            }
            else
            {
                l=mid+1;
            }
        }
        // int mid=l+(l-r)/2;
        return l;
    }

    private bool canEatBanana(int[] piles, int mid, int h)
    {
        int hrs = 0;
        foreach (int i in piles)
        {
            hrs+= i / mid;
            if(i%mid!=0)
            {
                hrs++;  
            }
        }
        return hrs<=h;
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        //Console.WriteLine(program.MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 8));
       // Console.WriteLine(program.MinEatingSpeed(new int[] { 30, 11, 23, 4, 20 }, 5));
        Console.WriteLine(program.MinEatingSpeed(new int[] { 30, 11, 23, 4, 20 }, 6));
        //Console.WriteLine(program.MinEatingSpeed(new int[] { 312884470 }, 312884469));
    }
}