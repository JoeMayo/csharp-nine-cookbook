using System.Text.Json.Serialization;

namespace Section_07_04
{
    public class PurchaseItem
    {
        [JsonPropertyName("serialNo")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("qty")]
        public float Quantity { get; set; }

        [JsonPropertyName("amount")]
        public decimal Price { get; set; }
    }
}
