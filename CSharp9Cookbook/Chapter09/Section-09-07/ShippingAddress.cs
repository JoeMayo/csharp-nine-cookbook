using System;

namespace Section_09_07
{
    public record ShippingAddress : AddressBase
    {
        public ShippingAddress(
            string street,
            string city,
            string state,
            string zip,
            string deliveryInstructions)
            : base(street, city, state, zip)
        {
            if (street.Contains("P.O. Box"))
                throw new ArgumentException(
                    "P.O. Boxes aren't allowed");

            DeliveryInstructions = deliveryInstructions;
        }

        public string DeliveryInstructions { get; init; }
    }
}
