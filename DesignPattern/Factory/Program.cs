using Factory;

internal class Program
{
    /// <summary>
    /// Factory Method is a creational design pattern that provides an interface for creating objects in a superclass,
    /// but allows subclasses to alter the type of objects that will be created.
    /// 
    /// The Factory Method pattern suggests that you replace direct object construction calls with calls to
    /// a special factory method.
    /// it’s being called from within the factory method. 
    /// Objects returned by a factory method are often referred to as products.
    /// 
    /// The Product declares the interface, which is common to all objects that can be produced by the creator and its subclasses.
    /// 
    /// Concrete Products are different implementations of the product interface.
    /// 
    /// The Creator class declares the factory method that returns new product objects. 
    /// It’s important that the return type of this method matches the product interface.
    /// 
    /// Concrete Creators override the base factory method so it returns a different type of product.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        IVehicle vehicle = VehicleFactory.GetVehicle("car");
        IVehicle vehicle2= VehicleFactory.GetVehicle("car");

        Console.WriteLine("Hello, World!");
    }
}