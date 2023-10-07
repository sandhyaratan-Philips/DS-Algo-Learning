internal class Program
{
    /// <summary>
    /// Proxy is a structural design pattern that lets you provide a substitute or placeholder for another object. 
    /// A proxy controls access to the original object, 
    /// allowing you to perform something either before or after the request gets through to the original object.
    /// 
    /// Subject
    // This is an interface having members that will be implemented by RealSubject and Proxy class.

    // RealSubject
    //This is a class which we want to use more efficiently by using proxy class.

    //Proxy
    //This is a class which holds the instance of RealSubject class and can access RealSubject class members as required.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        ProxyClient proxy = new ProxyClient();
        Console.WriteLine("Data from Proxy Client = {0}", proxy.GetData());

        Console.ReadKey();
    }
}

/// <summary>
/// The 'Subject interface
/// </summary>
public interface IClient
{
    string GetData();
}

/// <summary>
/// The 'RealSubject' class
/// </summary>
public class RealClient : IClient
{
    string Data;
    public RealClient()
    {
        Console.WriteLine("Real Client: Initialized");
        Data = "Dot Net Tricks";
    }

    public string GetData()
    {
        return Data;
    }
}

/// <summary>
/// The 'Proxy Object' class
/// </summary>
public class ProxyClient : IClient
{
    RealClient client = new RealClient();
    public ProxyClient()
    {
        Console.WriteLine("ProxyClient: Initialized");
    }

    public string GetData()
    {
        return client.GetData();
    }
}
