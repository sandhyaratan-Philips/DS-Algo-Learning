// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

internal class Program
{
    /// <summary>
    /// Bridge is a structural design pattern that lets you split a large class or a set of closely related classes
    /// into two separate hierarchies—abstraction 
    /// and implementation—which can be developed independently of each other.
    /// 
    /// Abstraction
    ///This is an abstract class and containing members that define an abstract business object and 
    ///its functionality.It contains a reference to an object of type Bridge. It can also act as 
    ///the base class for other abstractions
    ///
    /// Redefined Abstraction
    ///This is a class which inherits from the Abstraction class. It extends the interface defined by Abstraction class.
    ///
    ///Bridge
    ///This is an interface which acts as a bridge between the abstraction class and implementer classes and also makes the 
    ///functionality of implementer class independent from the abstraction class.
    ///
    ///ImplementationA & ImplementationB
    ///These are classes which implement the Bridge interface and also provide the implementation details for the associated Abstraction class.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        IMessageSender email = new EmailSender();
        IMessageSender queue = new MSMQSender();
        IMessageSender web = new WebServiceSender();

        Message message = new SystemMessage();
        message.Subject = "Test Message";
        message.Body = "Hi, This is a Test Message";

        message.MessageSender = email;
        message.Send();

        message.MessageSender = queue;
        message.Send();

        message.MessageSender = web;
        message.Send();

        UserMessage usermsg = new UserMessage();
        usermsg.Subject = "Test Message";
        usermsg.Body = "Hi, This is a Test Message";
        usermsg.UserComments = "I hope you are well";

        usermsg.MessageSender = email;
        usermsg.Send();

        Console.ReadKey();
    }
}

/// <summary>
/// The 'Abstraction' class
/// </summary>
public abstract class Message
{
    public IMessageSender MessageSender { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public abstract void Send();
}

/// <summary>
/// The 'RefinedAbstraction' class
/// </summary>
public class SystemMessage : Message
{
    public override void Send()
    {
        MessageSender.SendMessage(Subject, Body);
    }
}

/// <summary>
/// The 'RefinedAbstraction' class
/// </summary>
public class UserMessage : Message
{
    public string UserComments { get; set; }

    public override void Send()
    {
        string fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
        MessageSender.SendMessage(Subject, fullBody);
    }
}

/// <summary>
/// The 'Bridge/Implementor' interface
/// </summary>
public interface IMessageSender
{
    void SendMessage(string subject, string body);
}

/// <summary>
/// The 'ConcreteImplementor' class
/// </summary>
public class EmailSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        Console.WriteLine("Email\n{0}\n{1}\n", subject, body);
    }
}

/// <summary>
/// The 'ConcreteImplementor' class
/// </summary>
public class MSMQSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        Console.WriteLine("MSMQ\n{0}\n{1}\n", subject, body);
    }
}

/// <summary>
/// The 'ConcreteImplementor' class
/// </summary>
public class WebServiceSender : IMessageSender
{
    public void SendMessage(string subject, string body)
    {
        Console.WriteLine("Web Service\n{0}\n{1}\n", subject, body);
    }
}
