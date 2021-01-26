﻿using System;
using System.Linq;

namespace Section_04_01
{
    class Program
    {
        static void Main()
        {
            var context = new InMemoryContext();

            var salesPersonLookup =
                (from person in context.SalesPeople
                 select new
                 {
                     person.ID,
                     person.Name
                 })
                .ToList();

            Console.WriteLine("Sales People");

            salesPersonLookup.ForEach(person => 
                Console.WriteLine($"{person.ID}. {person.Name}"));
        }
    }
}
