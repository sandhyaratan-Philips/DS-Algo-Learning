using Recursion;

internal class Program
{
    private static void Main(string[] args)
    {
        TowerOfHanoi t=new TowerOfHanoi();
        t.Hanoi(3,'A','B','C');
        Console.WriteLine("Hello, World!");
    }
}