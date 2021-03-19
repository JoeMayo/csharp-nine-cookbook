using System;
using System.Threading.Tasks;

namespace Section_06_08
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                var checkoutSvc = new CheckoutService();

                string result = await checkoutSvc.StartBigO1Async();
                //string result = await checkoutSvc.StartBigONAsync();
                //string result = await checkoutSvc.StartBigONSquaredAsync();

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
