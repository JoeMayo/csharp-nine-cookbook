namespace Section_07_05
{
    public class PurchaseOrderService
    {
        public string Get(int poID)
        {
            // get HTTP request

            return @"{
    ""company_name"": ""Acme, Inc."",
    ""address"": ""123 4th St."",
    ""phone"": ""555-835-7609"",
    ""additional_info"": {
        ""terms"": ""Net 30"",
        ""poc"": ""J. Smith"",
    },
    ""status"": ""Processing"",
    ""items"": [
        {
            ""serial_number"": ""123"",
            ""description"": ""Widget"",
            ""quantity"": 5,
            ""price"": 13.95
        }
    ]
}";
        }
    }
}
