using AddressUtilities;
using System;

namespace AddressManager
{
    class Program
    {
        static void Main()
        {
            AddressService addressSvc = AddressService.Create();

            addressSvc
                .GetAddresses()
                .ForEach(address =>
                    Console.WriteLine(address));
        }
    }
}
