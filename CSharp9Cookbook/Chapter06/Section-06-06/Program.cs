using System;
using System.Threading.Tasks;

namespace Section_06_06
{
    class Program
    {
        static async Task Main()
        {
            var checkoutSvc = new CheckoutService();

            string result = await checkoutSvc.StartAsync();

            Console.WriteLine($"Result: {result}");
        }
    }
}
