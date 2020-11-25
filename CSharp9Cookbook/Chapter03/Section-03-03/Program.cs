using System;
using System.Collections.Generic;

namespace Section_03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessOrderOld("Cust1", new List<string> { "Item 1", "item 2" });
            ProcessOrderNew("Cust2", new List<string> { "Item 3", "item 4" });
        }

        static void ProcessOrderOld(string customer, List<string> lineItems)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), $"{nameof(customer)} is required.");
            }

            if (lineItems == null)
            {
                throw new ArgumentNullException(nameof(lineItems), $"{nameof(lineItems)} is required.");
            }

            Console.WriteLine($"Processed {customer}");
        }

        static void ProcessOrderNew(string customer, List<string> lineItems)
        {
            _ = customer ?? throw new ArgumentNullException(nameof(customer), $"{nameof(customer)} is required.");
            _ = lineItems ?? throw new ArgumentNullException(nameof(lineItems), $"{nameof(lineItems)} is required.");

            Console.WriteLine($"Processed {customer}");
        }
    }
}
