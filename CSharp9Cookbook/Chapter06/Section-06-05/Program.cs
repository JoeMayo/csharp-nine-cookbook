using System;
using System.Threading.Tasks;

namespace Section_06_05
{
    class Program
    {
        static async Task Main()
        {
            var checkoutSvc = new CheckoutService();
            var checkoutStrm = new CheckoutStream();

            IProgress<CheckoutRequestProgress> progress =
                new Progress<CheckoutRequestProgress>(p =>
                {
                    Console.WriteLine(
                        $"\n" +
                        $"Total: {p.Total}, " +
                        $"{p.Message}" +
                        $"\n");
                });

            await foreach (var request in checkoutStrm.GetRequestsAsync(progress))
            {
                string result = await checkoutSvc.StartAsync(request);

                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
