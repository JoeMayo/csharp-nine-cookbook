using System.Collections.Generic;

namespace Section_07_04
{
    class Program
    {
        static void Main()
        {
            PurchaseOrder po = GetPurchaseOrder();
            new PurchaseOrderService().View(po);
        }

        static PurchaseOrder GetPurchaseOrder()
        {
            return new PurchaseOrder
            {
                CompanyName = "Acme, Inc.",
                Address = "123 4th St.",
                Phone = "555-835-7609",
                AdditionalInfo = new Dictionary<string, string>
                {
                    { "terms", "Net 30" },
                    { "poc", "J. Smith" }
                },
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem
                    {
                        Description = "Widget",
                        Price = 13.95m,
                        Quantity = 5,
                        SerialNumber = "123"
                    }
                }
            };
        }
    }
}
