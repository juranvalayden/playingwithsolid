using System;
using System.Collections.Generic;
using SOLID;

namespace SOLIDExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LiskovSubstitutionPrinciple();
            InterfaceSegregationPrinciple();

            Console.ReadLine();
        }

        private static void LiskovSubstitutionPrinciple()
        {
            var customers = new List<ICustomer>
            {
                new GoldCustomer(new EventViewerHandler()),
                new SilverCustomer(new FileErrorHandler()),
                // new InquiryCustomer() // This is no longer valid!
            };

            foreach (var customer in customers)
            {
                customer.Add();
            }
        }

        private static void InterfaceSegregationPrinciple()
        {
            // the old 1000 clients are using
            ICustomer oldCustomer = new Customer(new EventViewerHandler());
            oldCustomer.Add();

            //  the new clients can use both
            IRead newCustomer = new Customer(new FileErrorHandler());
            newCustomer.Add();
            newCustomer.Read();
        }

    }
}
