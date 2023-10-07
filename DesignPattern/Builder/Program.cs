using Builder;

internal class Program
{
    //Builder is a creational design pattern
    //that lets you construct complex objects step by step.
    //The pattern allows you to produce different types and representations of an object using
    //the same construction code.


    /// <summary>
    /// The Builder interface declares product construction steps that are common to all types of builders.
    /// 
    /// Concrete Builders provide different implementations of the construction steps. Concrete builders may 
    /// produce products that don’t follow the common interface.
    /// 
    /// Products are resulting objects. 
    /// Products constructed by different builders don’t have to belong to the same class hierarchy or interface.
    /// 
    /// The Director class defines the order in which to call construction steps,
    /// so you can create and reuse specific configurations of products.
    /// 
    /// The Client must associate one of the builder objects with the director. 
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Director director = new Director();

        CarBuilder builder = new CarBuilder();
        director.constructSportsCar(builder);
        Car car = builder.getProduct();

        CarManualBuilder builder1 = new CarManualBuilder();
        director.constructSportsCar(builder1);

        // The final product is often retrieved from a builder
        // object since the director isn't aware of and not
        // dependent on concrete builders and products.
        Manual manual = builder1.getProduct();
        Console.WriteLine("Hello, World!");
    }
}