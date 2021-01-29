using System;
using System.Linq;

namespace Section_04_02
{
    class Program
    {
        static void Main()
        {
            var context = new InMemoryContext();

            var salesProducts =
                (from person in context.SalesPeople
                 join product in context.Products on
                    (person.Region, person.ProductType)
                    equals
                    (product.Region, product.Type)
                 select new
                 {
                     Person = person.Name,
                     Product = product.Name,
                     product.Region,
                     product.Type
                 })
                .ToList();

            Console.WriteLine("Sales People\n");

            salesProducts.ForEach(salesProd =>
                Console.WriteLine(
                    $"Person: {salesProd.Person}\n" +
                    $"Product: {salesProd.Product}\n" +
                    $"Region: {salesProd.Region}\n" +
                    $"Type: {salesProd.Type}\n"));
        }
    }
}
