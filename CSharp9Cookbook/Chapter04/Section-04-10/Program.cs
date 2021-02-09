using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Section_04_10
{
    class Program
    {
        static void Main()
        {
            List<SalesPerson> salesPeople = new InMemoryContext().SalesPeople;
            var result =
                (from person in salesPeople.AsParallel()
                 select ProcessPerson(person))
                .ToList();
        }

        static SalesPerson ProcessPerson(SalesPerson person)
        {
            Console.WriteLine(
                $"Starting sales person " +
                $"#{person.ID}. {person.Name}");

            // complex in-memory processing
            Thread.Sleep(500);

            Console.WriteLine(
                $"Completed sales person " +
                $"#{person.ID}. {person.Name}");

            return person;
        }
    }
}