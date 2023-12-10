namespace HW4_Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, HW 4!");

            ICar bmwCar1 = new BMWCar();
            bmwCar1.BuildCar();
            Console.WriteLine(bmwCar1 + "\n");

            //Adding Diesel Engine to the bmwCar1
            DieselCarDecorator carWithDieselEngine = new DieselCarDecorator(bmwCar1);
            carWithDieselEngine.BuildCar();

            Console.WriteLine();

            //Adding Petrol Engine to the bmwCar2
            ICar bmwCar2 = new BMWCar();
            PetrolCarDecorator carWithPetrolEngine = new PetrolCarDecorator(bmwCar2);
            carWithPetrolEngine.BuildCar();

            Console.WriteLine();
            Console.WriteLine($"bmwCar1 ID = {bmwCar1.GetHashCode()}");
            
            //Chenge Diesel to Petrol in the bmwCar1
            PetrolCarDecorator carWithPetrolEngine2 = new PetrolCarDecorator(bmwCar1);
            carWithPetrolEngine2.BuildCar();
            Console.WriteLine($"bmwCar1 ID = {bmwCar1.GetHashCode()}");
        }
    }

    public interface ICar
    { 
        ICar BuildCar();
    }

    public class BMWCar : ICar
    {
        private string CarName = "BMW";
        public string CarBody { get; set; }
        public string CarDoor { get; set; }
        public string CarWheels { get; set; }
        public string CarGlass { get; set; }
        public string Engine { get; set; }
        public override string ToString()
        {
            return "BMWCar [CarName=" + CarName + ", CarBody=" + CarBody + ", CarDoor=" + CarDoor + ", CarWheels="
                            + CarWheels + ", CarGlass=" + CarGlass + ", Engine=" + Engine + "]";
        }
        public ICar BuildCar()
        {
            CarBody = "carbon";
            CarDoor = "4 car doors";
            CarWheels = "4 car wheels";
            CarGlass = "6 car glasses";
            return this;
        }
    }

    public abstract class CarDecorator : ICar
    {
        protected ICar car;
        public CarDecorator(ICar car)
        {
            this.car = car;
        }
        public virtual ICar BuildCar()
        {
            return car.BuildCar();
        }
    }

    class PetrolCarDecorator : CarDecorator
    {
        public PetrolCarDecorator(ICar car) : base(car)
        {
        }

        public override ICar BuildCar()
        {
            car.BuildCar();
            AddEngine(car);
            return car;
        }
        public void AddEngine(ICar car)
        {
            if (car is BMWCar BMWCar)
            {
                BMWCar.Engine = "Petrol Engine";
                Console.WriteLine("PetrolCarDecorator added Petrol Engine to the Car : " + car);
            }
        }
    }
    class DieselCarDecorator : CarDecorator
    {
        public DieselCarDecorator(ICar car) : base(car)
        {
        }

        public override ICar BuildCar()
        {
            car.BuildCar();
            AddEngine(car);
            return car;
        }
        public void AddEngine(ICar car)
        {
            if (car is BMWCar BMWCar)
            {
                BMWCar.Engine = "Diesel Engine";
                Console.WriteLine("DieselCarDecorator added Diesel Engine to the Car : " + car);
            }
        }
    }
}
