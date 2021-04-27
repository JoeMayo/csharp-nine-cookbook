using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Section_07_08
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseOrder po = GetPurchaseOrder();

            XNamespace or = "https://www.oreilly.com";

            XElement poXml =
                new XElement(or + nameof(PurchaseOrder),
                    new XElement(
                        or + nameof(PurchaseOrder.Address),
                        po.Address),
                    new XElement(
                        or + nameof(PurchaseOrder.CompanyName),
                        po.CompanyName),
                    new XElement(
                        or + nameof(PurchaseOrder.Phone),
                        po.Phone),
                    new XElement(
                        or + nameof(PurchaseOrder.Status),
                        po.Status),
                    new XElement(
                        or + nameof(PurchaseOrder.AdditionalInfo),
                        (from info in po.AdditionalInfo
                         select
                             new XElement(
                                 or + info.Key,
                                 info.Value))
                        .ToList()),
                    new XElement(
                        or + nameof(PurchaseOrder.Items),
                        (from item in po.Items
                         select new XElement(
                             or + nameof(PurchaseItem),
                             new XAttribute(
                                 nameof(PurchaseItem.SerialNumber),
                                 item.SerialNumber),
                             new XElement(
                                 or + nameof(PurchaseItem.Description),
                                 item.Description),
                             new XElement(
                                 or + nameof(PurchaseItem.Price),
                                 item.Price),
                             new XElement(
                                 or + nameof(PurchaseItem.Quantity),
                                 item.Quantity)))
                        .ToList()));

            Console.WriteLine(poXml);
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
                    { "Terms", "Net 30" },
                    { "POC", "J. Smith" }
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
