using System;

namespace Section_1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            new HealthChecksObjects().PerformHealthChecks(5);
            new HealthChecksGeneric().PerformHealthChecks(5);
        }
    }
}
