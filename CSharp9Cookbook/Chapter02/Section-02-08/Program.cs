using System;
using System.Collections.Generic;

namespace Section_02_08
{
    class Program
    {
        readonly IInvoiceRepository invoiceRep;

        public Program(IInvoiceRepository invoiceRep)
        {
            this.invoiceRep = invoiceRep;
        }

        static void Main()
        {
            new Program(new InvoiceRepository()).Run();
        }

        void Run()
        {
            List<InvoiceCategory> categories = invoiceRep.GetInvoiceCategories();

            foreach (var category in categories)
                Console.WriteLine($"ID: {category.ID}, Name: {category.Name}");
        }
    }
}
