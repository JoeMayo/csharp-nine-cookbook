using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Section_03_10
{
    class Program
    {
        static void Main()
        {
            List<InvoiceItem> lineItems = GetInvoiceItems();

            DoStringConcatenation(lineItems);

            DoStringBuilderConcatenation(lineItems);
        }

        static string DoStringConcatenation(List<InvoiceItem> lineItems)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            string report = "";

            foreach (var item in lineItems)
                report += $"{item.Cost:C} - {item.Description}";

            stopwatch.Stop();
            Console.WriteLine($"Time for String Concatenation: {stopwatch.ElapsedMilliseconds}");

            return report;
        }

        static string DoStringBuilderConcatenation(List<InvoiceItem> lineItems)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var reportBuilder = new StringBuilder();

            foreach (var item in lineItems)
                reportBuilder.Append($"{item.Cost:C} - {item.Description}");

            stopwatch.Stop();
            Console.WriteLine($"Time for String Builder Concatenation: {stopwatch.ElapsedMilliseconds}");

            return reportBuilder.ToString();
        }

        static List<InvoiceItem> GetInvoiceItems()
        {
            const int ItemCount = 1000;

            var items = new List<InvoiceItem>();
            var rand = new Random();

            for (int i = 0; i < ItemCount; i++)
                items.Add(
                    new InvoiceItem
                    {
                        Cost = rand.Next(i),
                        Description = "Invoice Item #" + (i + 1)
                    });

            return items;
        }
    }

    class InvoiceItem
    {
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
