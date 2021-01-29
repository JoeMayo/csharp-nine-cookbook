using System;
using System.Collections.Generic;
using System.Linq;

namespace Section_04_06
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesPeopleWithoutComparer =
                (from person in new InMemoryContext().SalesPeople
                 select person)
                .Distinct()
                .ToList();

            PrintResults(salesPeopleWithoutComparer, "Without Comparer");

            var salesPeopleWithComparer =
                (from person in new InMemoryContext().SalesPeople
                 select person)
                .Distinct(new SalesPerson())
                .ToList();

            PrintResults(salesPeopleWithComparer, "With Comparer");
        }

        static void PrintResults(List<SalesPerson> salesPeople, string title)
        {
            Console.WriteLine($"\n{title}\n");

            salesPeople.ForEach(person =>
                Console.WriteLine($"{person.ID}. {person.Name}"));
        }
    }
}
