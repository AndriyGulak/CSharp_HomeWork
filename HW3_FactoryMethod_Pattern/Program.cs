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
        public abstract ITransport FactoryMethod();

        public string Send()
        {
            var product = FactoryMethod();
            var result = "Delivered by "  + product.Delivery();

            return result;
        }
    }

    class RoadLogistic : Logistic
    {
        public override ITransport FactoryMethod()
        {
            return new Truck();
        }
    }

    class SeaLogistic : Logistic
    {
        public override ITransport FactoryMethod()
        {
            return new Ship();
        }
    }

    public interface ITransport
    {
        string Delivery();
    }

    class Truck : ITransport
    {
        public string Delivery()
        {
            return "Truck";
        }
    }

    class Ship : ITransport
    {
        public string Delivery()
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

        public void ClientCode(Logistic logistic)
        {
            Console.WriteLine("I do not care about logistic.\n" + logistic.Send());
        }
    }
}
