using System;
using System.Collections.Generic;

namespace Section_03_04
{
    class OrderLibraryWithNull
    {
        // null property
        public string? DealOfTheDay { get; set; }

        // method with null parameter
        public void AddItem(string? item)
        {
            _ = item ?? throw new ArgumentNullException(nameof(item), $"{nameof(item)} must not be null");

            Console.Write(item.ToString());
        }


        // method with null return value
        public List<string>? GetItems()
        {
            return null;
        }


        // method with null type parameter
        public void AddItems(List<string?> items)
        {
            foreach (var item in items)
                Console.WriteLine(item?.ToString() ?? "None");
        }
    }
}
