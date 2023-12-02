namespace HW3_FactoryMethod_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, HW 3 !");
            
            new Client().Shipping("Road");
            new Client().Shipping("Sea");
        }
    }

    abstract class Logistic
    {
        public abstract Itransport FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Delivered by "  + product.Operation();

            return result;
        }
    }

    class RoadLogistic : Logistic
    {
        public override Itransport FactoryMethod()
        {
            return new Truck();
        }
    }

    class SeaLogistic : Logistic
    {
        public override Itransport FactoryMethod()
        {
            return new Ship();
        }
    }

    public interface Itransport
    {
        string Operation();
    }

    class Truck : Itransport
    {
        public string Operation()
        {
            return "Truck";
        }
    }

    class Ship : Itransport
    {
        public string Operation()
        {
            return "Ship";
        }
    }

    class Client
    {
        public void Shipping(string shippingBy)
        {
            if (shippingBy == "Road")
                ClientCode(new RoadLogistic());

            if (shippingBy == "Sea")
                ClientCode(new SeaLogistic());
        }

        public void ClientCode(Logistic creator)
        {
            Console.WriteLine("I do not care about logistic.\n" + creator.SomeOperation());
        }
    }
}
