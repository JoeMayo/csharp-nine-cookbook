using System.Collections.Generic;

namespace Section_02_08
{
    public class InvoiceRepository : IInvoiceRepository
    {
        static List<InvoiceCategory> invoiceCategories;

        public List<InvoiceCategory> GetInvoiceCategories()
        {
            if (invoiceCategories == null)
                invoiceCategories = GetInvoiceCategoriesFromDB();

            return invoiceCategories;
        }

        List<InvoiceCategory> GetInvoiceCategoriesFromDB()
        {
            return new List<InvoiceCategory>
            {
                new InvoiceCategory { ID = 1, Name = "Government" },
                new InvoiceCategory { ID = 2, Name = "Financial" },
                new InvoiceCategory { ID = 3, Name = "Enterprise" },
            };
        }
    }
}
