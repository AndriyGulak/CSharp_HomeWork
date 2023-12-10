namespace HW4_ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, HW 4 !");

            // Setup processing chain
            var validation = new ValidationHandler();
            var discount = new DiscountHandler();
            var payment = new PaymentHandler();
            var shipping = new ShippingHandler();

            validation.SetNext(discount);
            discount.SetNext(payment);
            payment.SetNext(shipping);

            var order = new Order();
            validation.Process(order);
        }

    }

    public class Order
    {
        public bool IsValid { get; set; } = true;
        public void ApplyDiscount()
        {
            Console.WriteLine("Discount applied...");
        }
        public bool ProcessPayment()
        {
            Console.WriteLine("Payment processed...");
            return false; // set = TRUE to execute full order processing chain
        }
        public void Ship()
        {
            Console.WriteLine("Order shiped...");
        }
    }
    public interface IOrderHendler
    {
            void SetNext(IOrderHendler hendler);
            void Process(Order order);
    }

        //Abstract Handler
    public abstract class OrderHandler : IOrderHendler
    {
        protected IOrderHendler nextHandler;
        public void SetNext(IOrderHendler hendler)
        {
            this.nextHandler = hendler;
        }
        public abstract void Process(Order order);
    }

    //Concrete Handlers
    public class ValidationHandler : OrderHandler
    {
        public override void Process(Order order)
        {
            if (order.IsValid)
            {
                Console.WriteLine("Order validation passed.");
                if (nextHandler != null) nextHandler.Process(order);
            }
            else
            {
                Console.WriteLine("Order validation failed. Halting process.");
            }
        }
    }
    public class DiscountHandler : OrderHandler
    {
        public override void Process(Order order)
        {
            order.ApplyDiscount();
            Console.WriteLine("Discount applied to order if any.");
            if (nextHandler != null) nextHandler.Process(order);
        }
    }

    public class PaymentHandler : OrderHandler
    {
        public override void Process(Order order)
        {
            if (order.ProcessPayment())
            {
                Console.WriteLine("Payment processed successfully.");
                if (nextHandler != null) nextHandler.Process(order);
            }
            else
            {
                Console.WriteLine("Payment processing failed. Halting process.");
            }
        }
    }

    public class ShippingHandler : OrderHandler
    {
        public override void Process(Order order)
        {
            order.Ship();
            Console.WriteLine("Order shipped to customer.");
        }
    }

}
