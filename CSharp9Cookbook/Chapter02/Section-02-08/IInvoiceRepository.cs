using System.Collections.Generic;

namespace Section_02_08
{
    public interface IInvoiceRepository
    {
        List<InvoiceCategory> GetInvoiceCategories();
    }
}