using System;
using System.Threading.Tasks;

namespace Section_06_01
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var checkoutSvc = new CheckoutService();
        //    string result = string.Empty;

        //    Task<string> startedTask = checkoutSvc.StartAsync();
        //    startedTask.Wait();
        //    result = startedTask.Result;

        //    Console.WriteLine($"Result: {result}");
        //}

        static async Task Main()
        {
            var checkoutSvc = new CheckoutService();

            string result = await checkoutSvc.StartAsync();

            Console.WriteLine($"Result: {result}");
        }
    }
}
