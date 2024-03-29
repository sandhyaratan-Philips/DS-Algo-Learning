﻿internal class Program
{
    /// <summary>
    /// Abstract Factory is a creational design pattern that lets you produce families of related objects without specifying their concrete classes.
    /// 
    /// Abstract Products declare interfaces for a set of distinct but related products which make up a product family.
    /// 
    /// Concrete Products are various implementations of abstract products, grouped by variants. Each abstract product (chair/sofa) must be implemented in all given variants (Victorian/Modern).
    /// 
    /// The Abstract Factory interface declares a set of methods for creating each of the abstract products.
    /// 
    /// Concrete Factories implement creation methods of the abstract factory. Each concrete factory corresponds to a specific variant of products and creates only those product variants.
    /// 
    /// Although concrete factories instantiate concrete products, signatures of their creation methods must return corresponding abstract products. This way the client code that uses a factory doesn’t get coupled to the specific variant of the product it gets from a factory. The Client can work with any concrete factory/product variant, as long as it communicates with their objects via abstract interfaces.
    /// 
    /// 
    /// 
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        VehicleFactory honda = new HondaFactory();
        VehicleClient hondaclient = new VehicleClient(honda, "Regular");

        Console.WriteLine("******* Honda **********");
        Console.WriteLine(hondaclient.GetBikeName());
        Console.WriteLine(hondaclient.GetScooterName());

        hondaclient = new VehicleClient(honda, "Sports");
        Console.WriteLine(hondaclient.GetBikeName());
        Console.WriteLine(hondaclient.GetScooterName());

        VehicleFactory hero = new HeroFactory();
        VehicleClient heroclient = new VehicleClient(hero, "Regular");

        Console.WriteLine("******* Hero **********");
        Console.WriteLine(heroclient.GetBikeName());
        Console.WriteLine(heroclient.GetScooterName());

        heroclient = new VehicleClient(hero, "Sports");
        Console.WriteLine(heroclient.GetBikeName());
        Console.WriteLine(heroclient.GetScooterName());

        Console.ReadKey();
    }
    interface VehicleFactory
    {
        Bike GetBike(string Bike);
        Scooter GetScooter(string Scooter);
    }

    /// <summary>
    /// The 'ConcreteFactory1' class.
    /// </summary>
    class HondaFactory : VehicleFactory
    {
        public Bike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }

        }

        public Scooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
            }

        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class.
    /// </summary>
    class HeroFactory : VehicleFactory
    {
        public Bike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }

        }

        public Scooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
            }

        }
    }

    /// <summary>
    /// The 'AbstractProductA' interface
    /// </summary>
    interface Bike
    {
        string Name();
    }

    /// <summary>
    /// The 'AbstractProductB' interface
    /// </summary>
    interface Scooter
    {
        string Name();
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class RegularBike : Bike
    {
        public string Name()
        {
            return "Regular Bike- Name";
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class SportsBike : Bike
    {
        public string Name()
        {
            return "Sports Bike- Name";
        }
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class RegularScooter : Scooter
    {
        public string Name()
        {
            return "Regular Scooter- Name";
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Scooty : Scooter
    {
        public string Name()
        {
            return "Scooty- Name";
        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class VehicleClient
    {
        Bike bike;
        Scooter scooter;

        public VehicleClient(VehicleFactory factory, string type)
        {
            bike = factory.GetBike(type);
            scooter = factory.GetScooter(type);
        }

        public string GetBikeName()
        {
            return bike.Name();
        }

        public string GetScooterName()
        {
            return scooter.Name();
        }

    }

}