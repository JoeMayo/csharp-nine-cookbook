using System;
using Microsoft.Extensions.Configuration;

namespace Section_07_03
{
    class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            string key = "CSharpCookbook:ApiKey";
            Console.WriteLine($"{key}: {config[key]}");
        }
    }
}
