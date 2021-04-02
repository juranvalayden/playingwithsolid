using System;

namespace SOLID
{
    // Solid Principle (S) - SRP[Single Responsibility Principle] - A class should only do one thing or one responsibility
    // Solid Principle (O) - OCP[Open and Closed Principle]       - Close the customer class for modification but leave it so that it can be extended (Modification means new functionality)
    // Solid Principle (L) - LSP[Liskov Substitution Principle]   - As per Polymorphism - The parent class should easily replace the can point to any of the child class objects during runtime without any issues
    // Solid Principle (I) - ISP[Interface Segregation Principle] - Adding a new interface instead of updating the current one see IRead
    // Solid Principle (D) - DIP[Dependency Inversion Principle]  - The customer class delegated the responsibility to the creating class/client (Inversion of Control/Dependency Injection)

    // Customer class should only do customer related tasks like validate
    public class Customer : IRead // Simple customer
    {
        private readonly IErrorHandler _errorHandler;

        public Customer(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        // We mark this as virtual so that classes can provide their own implementation and extend from this class
        public virtual double CalculateDiscount()
        {
            return 0;
        }

        public virtual void Add()
        {
            try
            {
                // Adds the customer to the database
            }
            catch (Exception e)
            {
                _errorHandler.HandleError(e);
            }
        }

        public void Read()
        {
            // Read
        }
    }

    // We are extending the customer
    public class GoldCustomer : Customer
    {
        public GoldCustomer(IErrorHandler errorHandler) : base(errorHandler)
        {
        }

        public override double CalculateDiscount()
        {
            return 10;
        }
    }

    public class SilverCustomer : Customer
    {
        public SilverCustomer(IErrorHandler errorHandler) : base(errorHandler)
        {
        }

        public override double CalculateDiscount()
        {
            return 7;
        }
    }

    public class InquiryCustomer : IInquiry // This customer simply does an inquiry in the shop and doesn't buy something
    {
        // Looks like a customer and acts like a customer but it is not a customer
        // It should not inherit from the customer class
        // LSP :- The parent objects should replace the child objects easily with polymorphism
        //public void Add()
        //{
        //    throw new NotImplementedException("For this inquiry customer we don't add to the database");
        //}

        public double CalculateDiscount()
        {
            return 2;
        }
    }

    // create 2 types of interfaces
    public interface IInquiry
    {
        double CalculateDiscount();
    }

    public interface ICustomer : IInquiry
    {
        void Add();
        // void Read(); -> ?????? just adding this will update 1000's of clients
    }

    public interface IRead : ICustomer
    {
        //
        void Read();
    }
}
