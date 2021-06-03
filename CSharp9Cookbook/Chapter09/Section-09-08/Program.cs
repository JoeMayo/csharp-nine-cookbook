using System;
using System.Collections.Generic;

namespace Section_09_08
{
    class Program
    {
        static void Main()
        {
            IEnumerable<Address> addresses = GetAddresses();

            foreach (var address in addresses)
            {
                foreach (var line in address)
                    Console.WriteLine(line);

                Console.WriteLine();
            }
        }

        static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address(
                    Street: "567 8th Ave.",
                    City: "Some Place",
                    State: "YY",
                    Zip: "12345-7890"),
                new Address(
                    Street: "569 8th Ave.",
                    City: "Some Place",
                    State: "YY",
                    Zip: "12345-7890")
            };
        }
    }
}
