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

        static List<Invoice> GetAllInvoices()
        {
            DateTime date = DateTime.Now;

            return new List<Invoice>
            {
                new Invoice { CustomerID = 1, Created = date },
                new Invoice { CustomerID = 2, Created = date },
                new Invoice { CustomerID = 1, Created = date },
                new Invoice { CustomerID = 3, Created = date }
            };
        }
    }
}
