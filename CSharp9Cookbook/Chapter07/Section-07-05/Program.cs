using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Section_07_05
{
    class Program
    {
        static void Main()
        {
            string poJson =
                new PurchaseOrderService()
                    .Get(poID: 123);

            var jsonOptions = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                Converters =
                {
                    new PurchaseOrderStatusConverter()
                },
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
                WriteIndented = true
            };

            PurchaseOrder po =
                JsonSerializer
                .Deserialize<PurchaseOrder>(poJson, jsonOptions);

            Console.WriteLine($"{po.CompanyName}");
            Console.WriteLine($"{po.AdditionalInfo["terms"]}");
            Console.WriteLine($"{po.Items[0].Description}");

            string poJson2 = JsonSerializer.Serialize(po, jsonOptions);

            Console.WriteLine(poJson2);
        }
    }
}
