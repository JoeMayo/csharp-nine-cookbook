using System.Collections.Generic;

namespace Section_07_07
{
    public class PurchaseOrder
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public PurchaseOrderStatus Status { get; set; }

        public Dictionary<string, string> AdditionalInfo { get; set; }

        public List<PurchaseItem> Items { get; set; }
    }
}
