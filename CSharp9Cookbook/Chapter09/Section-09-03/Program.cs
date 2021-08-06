using System;

namespace Section_09_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Address addressObjectInit = new()
            {
                Street = "123 4th St.",
                City = "My City",
                State = "ZZ",
                Zip = "55555-3333"
            };

            // not allowed
            //addressObjectInit.City = "A Locality";

            // target typed with ctor init
            Address addressCtorInit = new(
                street: "567 8th Ave.",
                city: "Some Place",
                state: "YY",
                zip: "12345-7890");

            // not allowed
            //addressCtorInit.Zip = "98765";
        }
    }
}
