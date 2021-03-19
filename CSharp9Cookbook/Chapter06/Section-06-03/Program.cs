using System;
using System.Threading.Tasks;

namespace Section_06_03
{
    class Program
    {
        static async Task Main()
        {
            var checkoutSvc = new CheckoutService();
            var checkoutStrm = new CheckoutStream();

            await foreach (var request in checkoutStrm.GetRequestsAsync())
            {
                string result = await checkoutSvc.StartAsync(request);

                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
