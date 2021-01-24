using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Section_03_09
{
    class Program
    {
        public static async Task Main()
        {
            const int DelayMilliseconds = 500;
            const int RetryCount = 3;

            bool success = false;
            int tryCount = 0;

            try
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Getting Orders");
                        await GetOrdersAsync();

                        success = true;
                    }
                    catch (HttpRequestException hre)
                        when (hre.StatusCode == HttpStatusCode.RequestTimeout)
                    {
                        tryCount++;

                        int millisecondsToDelay = DelayMilliseconds * tryCount;
                        // or Math.Pow(DelayMilliseconds, tryCount);

                        Console.WriteLine(
                            $"Exception during processing - " +
                            $"delaying for {millisecondsToDelay} milliseconds");

                        await Task.Delay(millisecondsToDelay);
                    }

                } while (tryCount < RetryCount);
            }
            finally
            {
                if (success)
                    Console.WriteLine("Operation Succeeded");
                else
                    Console.WriteLine("Operation Failed");
            }
        }

        static async Task GetOrdersAsync()
        {
            throw await Task.FromResult(
                new HttpRequestException(
                    "Timeout", null, HttpStatusCode.RequestTimeout));
        }
    }
}
