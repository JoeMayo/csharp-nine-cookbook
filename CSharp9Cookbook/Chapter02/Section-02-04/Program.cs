using System.Collections.Generic;

namespace Section_02_04
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IInvoice> invoices = GetInvoices();

            foreach (var invoice in invoices)
            {
                if (invoice.IsApproved())
                {
                    invoice.CalculateBalance();
                    invoice.PopulateLineItems();
                    invoice.SetDueDate();
                }
            }
        }

        static IEnumerable<IInvoice> GetInvoices()
        {
            return new List<IInvoice>
            {
                new BankInvoice(),
                new EnterpriseInvoice(),
                new GovernmentInvoice()
            };
        }
    }
}
