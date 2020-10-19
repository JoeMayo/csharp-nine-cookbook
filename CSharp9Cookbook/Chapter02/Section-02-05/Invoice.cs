using System;
using System.Collections.Generic;

namespace Section_02_05
{
    public class Invoice : IEquatable<Invoice>
    {
        public int CustomerID { get; set; }

        public DateTime Created { get; set; }

        public List<string> InvoiceItems { get; set; }

        public decimal Total { get; set; }

        public bool Equals(Invoice other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return
                CustomerID == other.CustomerID &&
                Created.Date == other.Created.Date;
        }

        public override bool Equals(object other)
        {
            return Equals(other as Invoice);
        }

        public override int GetHashCode()
        {
            return (CustomerID + Created.Ticks).GetHashCode();
        }

        public static bool operator ==(Invoice left, Invoice right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Invoice left, Invoice right)
        {
            return !(left == right);
        }
    }
}
