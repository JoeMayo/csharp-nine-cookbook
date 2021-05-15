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

        static void Main(string[] args)
        {
            // these still work
            var addressLocalVar = new Address();
            Address addressLocalOld = new Address();

            // new target typed local variable
            Address addressLocalNew = new();
        }
    }
}
