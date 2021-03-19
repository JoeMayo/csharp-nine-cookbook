using System;
using System.Threading.Tasks;

namespace Section_06_10
{
    public class ConsoleLogger : ILogger
    {
        public async Task<string> WriteAsync(string message)
        {
            Console.WriteLine($"Log: {message}");
            return await Task.FromResult(message);
        }
    }
}
