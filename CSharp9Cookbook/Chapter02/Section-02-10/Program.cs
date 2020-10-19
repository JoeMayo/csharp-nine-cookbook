using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Section_02_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string invoiceFile = GetInvoiceTransferFile();

            List<Invoice> invoices = ParseInvoices(invoiceFile);

            SaveInvoices(invoices);
        }

        static string GetInvoiceTransferFile()
        {
            return
                "Creator 1::8/05/20::Item 1\t35.05\tItem 2\t25.18\tItem 3\t13.13::Customer 1::Note 1\n" +
                "Creator 2::8/10/20::Item 1\t45.05::Customer 2::Note 2\n" +
                "Creator 1::8/15/20::Item 1\t55.05\tItem 2\t65.18::Customer 3::Note 3\n";
        }

        static List<Invoice> ParseInvoices(string invoiceFile)
        {
            var invoices = new List<Invoice>();

            var invoiceRegEx = new Regex(
                @"^.+?::(?<created>.+?)::(?<items>.+?)::(?<customer>.+?)::.+");

            foreach (var invoiceString in invoiceFile.Split('\n'))
            {
                Match match = invoiceRegEx.Match(invoiceString);

                if (match.Success)
                {
                    string matchCustomer = match.Groups["customer"].Value;
                    string matchCreated = match.Groups["created"].Value;
                    string matchItems = match.Groups["items"].Value;

                    Invoice invoice = GetInvoice(matchCustomer, matchCreated, matchItems);
                    invoices.Add(invoice);
                }
            }

            return invoices;
        }

        static Invoice GetInvoice(string matchCustomer, string matchCreated, string matchItems)
        {
            List<InvoiceItem> lineItems = GetLineItems(matchItems);

            DateTime.TryParse(matchCreated, out DateTime created);

            var invoice =
                new Invoice
                {
                    Customer = matchCustomer,
                    Created = created,
                    Items = lineItems
                };
            return invoice;
        }

        static List<InvoiceItem> GetLineItems(string matchItems)
        {
            var lineItems = new List<InvoiceItem>();

            string[] itemStrings = matchItems.Split('\t');

            for (int i = 0; i < itemStrings.Length; i += 2)
            {
                decimal.TryParse(itemStrings[i + 1], out decimal cost);
                lineItems.Add(
                    new InvoiceItem
                    {
                        Description = itemStrings[i],
                        Cost = cost
                    });
            }

            return lineItems;
        }

        static void SaveInvoices(List<Invoice> invoices)
        {
            Console.WriteLine($"{invoices.Count} invoices saved.");
        }
    }

    class InvoiceItem
    {
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }

    class Invoice
    {
        public string Customer { get; set; }
        public DateTime Created { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal Total { get; set; }
    }
}
