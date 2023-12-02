namespace HW3_Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, HW 3!");
            //Factory Method
            var director = new Director();
            var builder = new HouseBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalHouse();
            Console.WriteLine(builder.GetHouse().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.BuildGorgeousHouse();
            Console.WriteLine(builder.GetHouse().ListParts());

            // Using Builder without a Director class.
            Console.WriteLine("Custom product 1:");
            builder.BuildSwimmingPool();
            builder.BuildGarage();
            Console.WriteLine(builder.GetHouse().ListParts());
            
            Console.WriteLine("Custom product 2:");
            Console.WriteLine(builder.GetHouse().ListParts());
        }
    }
}
