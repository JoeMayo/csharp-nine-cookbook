using System;
using System.Collections.Generic;

namespace Section_02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Invoice> allInvoices = GetAllInvoices();

            Console.WriteLine($"# of All Invoices: {allInvoices.Count}");

            var invoicesToProcess = new List<Invoice>();

            foreach (var invoice in allInvoices)
            {
                if (!invoicesToProcess.Contains(invoice))
                    invoicesToProcess.Add(invoice);
            }

            Console.WriteLine($"# of Invoices to Process: {invoicesToProcess.Count}");
        }

        private static List<Invoice> GetAllInvoices()
        {
            return new List<Invoice>
            {
                new Invoice { CustomerID = 1, Created = DateTime.Now },
                new Invoice { CustomerID = 2, Created = DateTime.Now },
                new Invoice { CustomerID = 1, Created = DateTime.Now },
                new Invoice { CustomerID = 3, Created = DateTime.Now }
            };
        }
    }
}
