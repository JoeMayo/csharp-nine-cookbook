using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Section_07_04
{
    public class PurchaseOrder
    {
        [JsonPropertyName("company")]
        public string CompanyName { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("status")]
        public PurchaseOrderStatus Status { get; set; }

        [JsonPropertyName("other")]
        public Dictionary<string, string> AdditionalInfo { get; set; }

        [JsonPropertyName("details")]
        public List<PurchaseItem> Items { get; set; }
    }
}
