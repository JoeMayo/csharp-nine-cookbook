using System;
using System.Linq;

namespace Section_04_07
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal TotalSales = 0;

            var salesPeopleWithAddresses =
                (from person in new InMemoryContext().SalesPeople
                 let FullAddress =
                    $"{person.Address}\n" +
                    $"{person.City}, {person.PostalCode}"
                 let salesOkay = decimal.TryParse(person.TotalSales, out TotalSales)
                 select new
                 {
                     person.ID,
                     person.Name,
                     FullAddress,
                     TotalSales
                 })
                .ToList();

            Console.WriteLine($"\nSales People and Addresses\n");

            salesPeopleWithAddresses.ForEach(person =>
                Console.WriteLine(
                    $"{person.ID}. {person.Name}: {person.TotalSales:C}\n" +
                    $"{person.FullAddress}\n"));
        }
    }
}
