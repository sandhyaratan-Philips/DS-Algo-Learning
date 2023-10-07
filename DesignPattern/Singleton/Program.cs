using System.Xml.Linq;

internal class Program
{
    /// <summary>
    /// Singleton is a creational design pattern that lets you ensure that a class has only one instance,
    /// while providing a global access point to this instance.
    /// 
    /// The Singleton class declares the static method getInstance that returns the same instance of its own class.
    /// 
    /// 
    /// 
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Singleton.GetInstance.Show();
        Singleton.GetInstance.Show();
        Console.WriteLine("Hello, World!");
    }
}

public class Singleton
{
    private static Singleton instance = null;
    private Singleton() { }
    private static object lockThis = new object();

    public static Singleton GetInstance
    {
        get
        {
            lock (lockThis)
            {
                if (instance == null)
                    instance = new Singleton();

                return instance;
            }
        }
    }
    public void Show()
    {
        Console.WriteLine("Server Information is : Name=yoo");
    }
}