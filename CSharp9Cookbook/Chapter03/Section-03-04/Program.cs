using System;
using System.Collections.Generic;

namespace Section_03_04
{
    class Program
    {
        static void Main()
        {
            HandleNonNull();

            HandleWithNullNoHandling();

            HandleWithNullAndHandling();
        }

        static void HandleNonNull()
        {
            var orders = new OrderLibraryNonNull();

            string deal = orders.DealOfTheDay;
            Console.WriteLine(deal.ToUpper());

            orders.AddItem(null);
            orders.AddItems(new List<string> { "one", null });

            foreach (var item in orders.GetItems().ToArray())
            {
                Console.WriteLine(item.Trim());
            }
        }


        static void HandleWithNullNoHandling()
        {
            var orders = new OrderLibraryWithNull();

            string deal = orders.DealOfTheDay;
            Console.WriteLine(deal.ToUpper());

            orders.AddItem(null);
            orders.AddItems(new List<string> { "one", null });

            foreach (var item in orders.GetItems().ToArray())
            {
                Console.WriteLine(item.Trim());
            }
        }

        static void HandleWithNullAndHandling()
        {
            var orders = new OrderLibraryWithNull();

            string? deal = orders.DealOfTheDay;
            Console.WriteLine(deal?.ToUpper() ?? "Deals");

            orders.AddItem(null);
            orders.AddItems(new List<string?> { "one", null });

            List<string>? items = orders.GetItems();

            if (items != null)
                foreach (var item in items.ToArray())
                    Console.WriteLine(item.Trim());
        }
    }
}
