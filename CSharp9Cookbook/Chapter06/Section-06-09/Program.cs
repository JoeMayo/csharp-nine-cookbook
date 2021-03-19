using System;
using System.Threading;
using System.Threading.Tasks;

namespace Section_06_09
{
    class Program
    {
        static async Task Main()
        {
            var cancelSource = new CancellationTokenSource();
            var checkoutStrm = new CheckoutStream(cancelSource.Token);
            var checkoutSvc = new CheckoutService();

            IProgress<CheckoutRequestProgress> progress =
                new Progress<CheckoutRequestProgress>(p =>
                {
                    Console.WriteLine(
                        $"\n" +
                        $"Total: {p.Total}, " +
                        $"{p.Message}" +
                        $"\n");
                });

            int count = 1;

            await foreach (var request in checkoutStrm.GetRequestsAsync(progress))
            {
                string result = await checkoutSvc.StartAsync(request);

                Console.WriteLine($"Result: {result}");

                if (count++ >= 10)
                    break;

                if (count >= 5)
                    cancelSource.Cancel();
            }
        }
    }
}
