using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Section_07_06
{
    class Program
    {
        static void Main()
        {
            string poJson =
                new PurchaseOrderService()
                    .Get(poID: 123);

            JsonElement elm = JsonDocument.Parse(poJson).RootElement;

            JsonElement additional = elm.GetProperty("additional_info");
            JsonElement items = elm.GetProperty("items");

            if (additional.IsNull() || items.IsNull())
                throw new ArgumentException("incomplete PO");

            var po = new PurchaseOrder
            {
                Address = elm.GetString("address", "none"),
                CompanyName = elm.GetString("company_name", string.Empty),
                Phone = elm.GetString("phone", string.Empty),
                Status = elm.GetEnum("status", PurchaseOrderStatus.Received),
                Terms = additional.GetString("terms", string.Empty),
                POC = additional.GetString("poc", string.Empty),
                AdditionalInfo =
                    (from jElem in additional.EnumerateObject()
                     select jElem)
                    .ToDictionary(
                        key => key.Name,
                        val => val.Value.GetString()),
                Items =
                    (from jElem in items.EnumerateArray()
                     select new PurchaseItem
                     {
                         Description = jElem.GetString("description"),
                         Price = jElem.GetDecimal("price"),
                         Quantity = jElem.GetDouble("quantity"),
                         SerialNumber = jElem.GetString("serial_number")
                     })
                    .ToList()
            };

            Console.WriteLine($"{po.CompanyName}");
            Console.WriteLine($"{po.Terms}");
            Console.WriteLine($"{po.AdditionalInfo["terms"]}");
            Console.WriteLine($"{po.Items[0].Description}");
        }
    }
}
