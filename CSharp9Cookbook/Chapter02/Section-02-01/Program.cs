using System;
using System.Collections.Generic;
using System.Text;

namespace Section_02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<InvoiceItem> lineItems = GetInvoiceItems();

            DoStringConcatenation(lineItems);

            DoStringBuilderConcatenation(lineItems);
        }

        static string DoStringConcatenation(List<InvoiceItem> lineItems)
        {
            string report = "";

            foreach (var item in lineItems)
                report += $"{item.Cost:C} - {item.Description}\n";

            return report;
        }

        static string DoStringBuilderConcatenation(List<InvoiceItem> lineItems)
        {
            var reportBuilder = new StringBuilder();

            foreach (var item in lineItems)
                reportBuilder.Append($"{item.Cost:C} - {item.Description}\n");

            return reportBuilder.ToString();
        }

        static List<InvoiceItem> GetInvoiceItems()
        {
            var items = new List<InvoiceItem>();
            var rand = new Random();
            for (int i = 0; i < 100; i++)
                items.Add(
                    new InvoiceItem
                    {
                        Cost = rand.Next(i),
                        Description = "Invoice Item #" + (i+1)
                    });

            return items;
        }
    }

    public class InvoiceItem
    {
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
