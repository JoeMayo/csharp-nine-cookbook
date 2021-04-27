using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Section_07_05
{
    public class PurchaseOrder
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [JsonConverter(typeof(PurchaseOrderStatusConverter))]
        public PurchaseOrderStatus Status { get; set; }

        public Dictionary<string, string> AdditionalInfo { get; set; }

        public List<PurchaseItem> Items { get; set; }
    }
}
