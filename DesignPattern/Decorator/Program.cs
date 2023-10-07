using System.ComponentModel;

internal class Program
{
    /// <summary>
    /// Decorator is a structural design pattern that lets you attach new behaviors to objects 
    /// by placing these objects inside special wrapper objects that contain the behaviors.
    /// 
    /// Component
    ///   This is an interface containing members that will be implemented by ConcreteClass and Decorator.

    ///    ConcreteComponent
    ///This is a class which implements the Component interface.

    ///Decorator
    //This is an abstract class which implements the Component interface and contains the reference to a Component instance.This class also acts as base class for all decorators for components.

    ///ConcreteDecorator
    ///This is a class which inherits from Decorator class and provides a decorator for components.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        // Basic vehicle
        HondaCity car = new HondaCity();

        Console.WriteLine("Honda City base price are : {0}", car.Price);

        // Special offer
        SpecialOffer offer = new SpecialOffer(car);
        offer.DiscountPercentage = 25;
        offer.Offer = "25 % discount";

        Console.WriteLine("{1} @ Diwali Special Offer and price are : {0} ", offer.Price, offer.Offer);

        Console.ReadKey();
    }
}

/// <summary>
/// The 'Component' interface
/// </summary>
public interface Vehicle
{
    string Make { get; }
    string Model { get; }
    double Price { get; }
}

/// <summary>
/// The 'ConcreteComponent' class
/// </summary>
public class HondaCity : Vehicle
{
    public string Make
    {
        get { return "HondaCity"; }
    }

    public string Model
    {
        get { return "CNG"; }
    }

    public double Price
    {
        get { return 1000000; }
    }
}

/// <summary>
/// The 'Decorator' abstract class
/// </summary>
public abstract class VehicleDecorator : Vehicle
{
    private Vehicle _vehicle;

    public VehicleDecorator(Vehicle vehicle)
    {
        _vehicle = vehicle;
    }

    public string Make
    {
        get { return _vehicle.Make; }
    }

    public string Model
    {
        get { return _vehicle.Model; }
    }

    public double Price
    {
        get { return _vehicle.Price; }
    }

}

/// <summary>
/// The 'ConcreteDecorator' class
/// </summary>
public class SpecialOffer : VehicleDecorator
{
    public SpecialOffer(Vehicle vehicle) : base(vehicle) { }

    public int DiscountPercentage { get; set; }
    public string Offer { get; set; }

    public double Price
    {
        get
        {
            double price = base.Price;
            int percentage = 100 - DiscountPercentage;
            return Math.Round((price * percentage) / 100, 2);
        }
    }

}
