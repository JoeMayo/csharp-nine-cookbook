using System;

namespace Section_09_09
{
    class Program
    {
        static void Main()
        {
            AddressService addressSvc = new();

            foreach (var addresses in 
                addressSvc.GetAddresses(perPage: 3))
            {
                foreach (var address in addresses)
                {
                    Console.WriteLine(address);
                }

                Console.WriteLine("\nNew Page\n");
            }
        }
    }
}
