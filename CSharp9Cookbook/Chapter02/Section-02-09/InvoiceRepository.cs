using System;

namespace Section_02_09
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public InvoiceRepository()
        {
            Console.WriteLine("InvoiceRepository Instantiated.");
        }

        public void AddInvoiceCategory(string category)
        {
            Console.WriteLine($"for category: {category}");
        }
    }
}
