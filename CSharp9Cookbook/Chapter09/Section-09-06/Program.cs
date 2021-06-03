using System;

namespace Section_09_06
{
    class Program
    {
        static void Main(string[] args)
        {
            MailingAddress mailAddress = new(
                Street: "567 8th Ave.",
                City: "Some Place",
                State: "YY",
                Zip: "12345-7890",
                Email: "me@example.com",
                PreferEmail: true);

            ShippingAddress shipAddress = new(
                street: "567 8th Ave.",
                city: "Some Place",
                state: "YY",
                zip: "12345-7890",
                deliveryInstructions: "Ring Doorbell");

            Console.WriteLine($"Mail: {mailAddress}");
            Console.WriteLine($"Ship: {shipAddress}");

            Console.WriteLine(
                $"Derived types equal: " +
                $"{mailAddress == shipAddress}");

            AddressBase mailBase = mailAddress;
            AddressBase shipBase = shipAddress;
            Console.WriteLine(
                $"Base types equal: " +
                $"{mailBase == shipBase}");
        }
    }
}
