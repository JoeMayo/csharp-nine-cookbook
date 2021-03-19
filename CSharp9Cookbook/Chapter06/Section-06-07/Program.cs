using System;
using System.Threading.Tasks;

namespace Section_06_07
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                var checkoutSvc = new CheckoutService();

                string result = await checkoutSvc.StartAsync();

                Console.WriteLine($"Result: {result}");
            }
            catch (AggregateException aEx)
            {
                foreach (var ex in aEx.InnerExceptions)
                    Console.WriteLine($"Unable to complete: {ex}");
            }
        }
    }
}
