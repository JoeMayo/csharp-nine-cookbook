using System;
using System.Text.Json;

namespace Section_07_04
{
    public class PurchaseOrderService
    {
        public void View(PurchaseOrder po)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string poJson = JsonSerializer.Serialize(po, jsonOptions);

            // send HTTP request

            Console.WriteLine(poJson);
        }
    }
}
