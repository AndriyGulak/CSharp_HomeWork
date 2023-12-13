using System;

namespace HW5_Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, HW5 !");

            Subject iPhone = new Subject("iPhone Mobile", 10000, "Out Of Stock");
            Observer user1 = new Observer("Andrii");
            user1.AddSubscriber(iPhone);
            Observer user2 = new Observer("Ola");
            user2.AddSubscriber(iPhone);
            Observer user3 = new Observer("Max");
            user3.AddSubscriber(iPhone);
            Console.WriteLine("iPhone Mobile current state : " + iPhone.GetAvailability());
            Console.WriteLine();
            user3.RemoveSubscriber(iPhone);
            iPhone.SetAvailability("Available");

        }
    }

    public interface IObserver
    {
        void Update(string availability);
    }
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string ProductName { get; set; }
        private int ProductPrice { get; set; }
        private string Availability { get; set; }

        public Subject(string productName, int productPrice, string availability)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            Availability = availability;
        }
        public string GetAvailability()
        {
            return Availability;
        }
        public void SetAvailability(string availability)
        {
            this.Availability = availability;
            Console.WriteLine("Availability changed from Out of Stock to Available.");
            NotifyObservers();
        }
        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Observer Added : " + ((Observer)observer).UserName);
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            Console.WriteLine("Observer Removed : " + ((Observer)observer).UserName);
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            Console.WriteLine("Product Name :"
                            + ProductName + ", product Price : "
                            + ProductPrice + " is Now available. So, notifying all Registered users: ");
            Console.WriteLine();
            foreach (IObserver observer in observers)
            {
                observer.Update(Availability);
            }
        }
    }

    public class Observer : IObserver
    {
        public string UserName { get; set; }
        public Observer(string userName)
        {
            UserName = userName;
        }
        public void AddSubscriber(ISubject subject)
        {
            subject.RegisterObserver(this);
        }
        public void RemoveSubscriber(ISubject subject)
        {
            subject.RemoveObserver(this);
        }
        public void Update(string availabiliy)
        {
            Console.WriteLine("Hello " + UserName + ", Product is now " + availabiliy + " on eBay");
        }
    }

}
