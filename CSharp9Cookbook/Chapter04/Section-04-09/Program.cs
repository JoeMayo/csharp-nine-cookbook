using System;
using System.Collections.Generic;
using System.Linq;

namespace Section_04_09
{
    class Program
    {
        static void Main()
        {
            SalesPerson searchCriteria = GetCriteriaFromUser();

            List<SalesPerson> salesPeople = QuerySalesPeople(searchCriteria);

            PrintResults(salesPeople);
        }

        static SalesPerson GetCriteriaFromUser()
        {
            var person = new SalesPerson();

            Console.WriteLine("Sales Person Search");
            Console.WriteLine("(press Enter to skip an entry)\n");

            Console.Write($"{nameof(SalesPerson.Address)}: ");
            person.Address = Console.ReadLine();

            Console.Write($"{nameof(SalesPerson.City)}: ");
            person.City = Console.ReadLine();

            Console.Write($"{nameof(SalesPerson.Name)}: ");
            person.Name = Console.ReadLine();

            Console.Write($"{nameof(SalesPerson.PostalCode)}: ");
            person.PostalCode = Console.ReadLine();

            Console.Write($"{nameof(SalesPerson.ProductType)}: ");
            person.ProductType = Console.ReadLine();

            Console.Write($"{nameof(SalesPerson.Region)}: ");
            person.Region = Console.ReadLine();

            return person;
        }

        static List<SalesPerson> QuerySalesPeople(SalesPerson criteria)
        {
            var ctx = new InMemoryContext();

            var filters = new Dictionary<string, string>();

            IEnumerable<SalesPerson> salesPeopleQuery =
                from people in ctx.SalesPeople
                select people;

            if (!string.IsNullOrWhiteSpace(criteria.Address))
                filters[nameof(criteria.Address)] = criteria.Address;

            if (!string.IsNullOrWhiteSpace(criteria.City))
                filters[nameof(criteria.City)] = criteria.City;

            if (!string.IsNullOrWhiteSpace(criteria.Name))
                filters[nameof(criteria.Name)] = criteria.Name;

            if (!string.IsNullOrWhiteSpace(criteria.PostalCode))
                filters[nameof(criteria.PostalCode)] = criteria.PostalCode;

            if (!string.IsNullOrWhiteSpace(criteria.ProductType))
                filters[nameof(criteria.ProductType)] = criteria.ProductType;

            if (!string.IsNullOrWhiteSpace(criteria.Region))
                filters[nameof(criteria.Region)] = criteria.Region;

            salesPeopleQuery = salesPeopleQuery.WhereOr<SalesPerson>(filters);

            List<SalesPerson> salesPeople = salesPeopleQuery.ToList();

            return salesPeople;
        }

        static void PrintResults(List<SalesPerson> salesPeople)
        {
            Console.WriteLine("\nSales People\n");

            salesPeople.ForEach(person =>
                Console.WriteLine($"{person.ID}. {person.Name}"));
        }
    }
}
