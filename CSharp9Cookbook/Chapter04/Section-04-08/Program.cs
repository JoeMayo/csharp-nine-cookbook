using System;
using System.Collections.Generic;
using System.Linq;

namespace Section_04_08
{
    class Program
    {
        static InMemoryContext ctx = new InMemoryContext();

        static void Main()
        {
            System.Console.WriteLine("\nLINQ Set Operations");

            DoUnion();
            DoExcept();
            DoIntersection();

            System.Console.WriteLine("\nComplete.\n");
        }

        static void DoUnion()
        {
            var dataSource1 =
                (from person in ctx.SalesPeople
                 where person.ID < 3
                 select person)
                .ToList();

            var dataSource2 =
                (from person in ctx.SalesPeople
                 where person.ID > 2
                 select person)
                .ToList();

            List<SalesPerson> union = 
                dataSource1
                    .Union(dataSource2, new SalesPerson())
                    .ToList();

            PrintResults(union, "Union Results");
        }

        static void DoExcept()
        {
            var dataSource1 =
                (from person in ctx.SalesPeople
                 select person)
                .ToList();

            var dataSource2 =
                (from person in ctx.SalesPeople
                 where person.ID == 4
                 select person)
                .ToList();

            List<SalesPerson> union = 
                dataSource1
                    .Except(dataSource2, new SalesPerson())
                    .ToList();

            PrintResults(union, "Except Results");
        }

        static void DoIntersection()
        {
            var dataSource1 =
                (from person in ctx.SalesPeople
                 where person.ID < 4
                 select person)
                .ToList();

            var dataSource2 =
                (from person in ctx.SalesPeople
                 where person.ID > 2
                 select person)
                .ToList();

            List<SalesPerson> union = 
                dataSource1
                    .Intersect(dataSource2, new SalesPerson())
                    .ToList();

            PrintResults(union, "Intersect Results");
        }

        static void PrintResults(List<SalesPerson> salesPeople, string title)
        {
            Console.WriteLine($"\n{title}\n");

            salesPeople.ForEach(person =>
                Console.WriteLine($"{person.ID}. {person.Name}"));
        }
    }
}
