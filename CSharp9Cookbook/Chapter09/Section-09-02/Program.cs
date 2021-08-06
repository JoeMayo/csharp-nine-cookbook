using System;

namespace Section_09_02
{
    class Program
    {
        // doesn't work
        // var address = new Address();

        // this still works
        Address addressOld = new Address();

        // new target typed field
        Address addressNew = new();

        static void Main()
        {
            // these still work
            var addressLocalVar = new Address();
            Address addressLocalOld = new Address();

            // new target typed local variable
            Address addressLocalNew = new();

            // target typed with object ini
            Address addressObjectInit = new()
            {
                Street = "123 4th St.",
                City =   "My City",
                State =  "ZZ",
                Zip =    "55555-3333"
            };

            // target typed with ctor init
            Address addressCtorInit = new(
                street: "567 8th Ave.",
                city:   "Some Place",
                state:  "YY",
                zip:    "12345-7890");
        }
    }
}
