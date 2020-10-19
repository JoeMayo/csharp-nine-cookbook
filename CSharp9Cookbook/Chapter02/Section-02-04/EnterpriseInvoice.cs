using System;

namespace Section_02_04
{
    public class EnterpriseInvoice : IInvoice
    {
        public void CalculateBalance()
        {
            Console.WriteLine("Calculating balance for EnterpriseInvoice.");
        }

        public bool IsApproved()
        {
            Console.WriteLine("Checking approval for EnterpriseInvoice.");
            return true;
        }

        public void PopulateLineItems()
        {
            Console.WriteLine("Populating items for EnterpriseInvoice.");
        }

        public void SetDueDate()
        {
            Console.WriteLine("Setting due date for EnterpriseInvoice.");
        }
    }
}
