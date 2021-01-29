using System;
using System.Linq;

namespace Section_04_04
{
    class Program
    {
        static void Main()
        {
            var context = new InMemoryContext();

            var salesPeopleByRegion =
                (from person in context.SalesPeople
                 group person by person.Region into personGroup
                 select personGroup)
                .ToList();

            Console.WriteLine("Sales People by Region");

            foreach (var region in salesPeopleByRegion)
            {
                Console.WriteLine($"\nRegion: {region.Key}");

                foreach (var person in region)
                    Console.WriteLine($"  {person.Name}");
            }
        }
    }
}
