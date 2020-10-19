using System;
using System.Collections.Generic;

namespace Section_02_03
{
    class Program
    {
        static void Main()
        {
            List<InvoiceItem> lineItems = GetInvoiceItems();

            decimal total = 0;

            foreach (var item in lineItems)
                total += item.Cost;

            total = ApplyDiscount(total, CustomerType.Gold);

            Console.WriteLine($"Total Invoice Balance: {total:C}");

            decimal ApplyDiscount(decimal total, CustomerType customerType)
            {
                switch (customerType)
                {
                    case CustomerType.Bronze:
                        return total - total * .10m;
                    case CustomerType.Silver:
                        return total - total * .05m;
                    case CustomerType.Gold:
                        return total - total * .02m;
                    case CustomerType.None:
                    default:
                        return total;
                }
            }
        }

        static List<InvoiceItem> GetInvoiceItems()
        {
            var items = new List<InvoiceItem>();
            var rand = new Random();
            for (int i = 0; i < 100; i++)
                items.Add(
                    new InvoiceItem
                    {
                        Cost = rand.Next(i),
                        Description = "Invoice Item #" + (i + 1)
                    });

            return items;
        }
    }

    enum CustomerType
    {
        None,
        Bronze,
        Silver,
        Gold
    }

    class InvoiceItem
    {
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
