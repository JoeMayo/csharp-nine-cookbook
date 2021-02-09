using System.Collections.Generic;

namespace Section_04_06
{
    public class SalesPerson : IEqualityComparer<SalesPerson>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string ProductType { get; set; }

        public bool Equals(SalesPerson x, SalesPerson y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(SalesPerson obj)
        {
            return ID.GetHashCode();
        }
    }
}
