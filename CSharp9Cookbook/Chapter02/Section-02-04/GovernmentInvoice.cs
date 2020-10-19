using System;

namespace Section_02_04
{
    public class GovernmentInvoice : IInvoice
    {
        public void CalculateBalance()
        {
            Console.WriteLine("Calculating balance for GovernmentInvoice.");
        }

        public bool IsApproved()
        {
            Console.WriteLine("Checking approval for GovernmentInvoice.");
            return true;
        }

        public void PopulateLineItems()
        {
            Console.WriteLine("Populating items for GovernmentInvoice.");
        }

        public void SetDueDate()
        {
            Console.WriteLine("Setting due date for GovernmentInvoice.");
        }
    }
}
