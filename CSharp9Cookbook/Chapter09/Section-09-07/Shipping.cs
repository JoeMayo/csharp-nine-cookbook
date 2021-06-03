namespace Section_09_07
{
    class Shipping : DeliveryBase
    {
        public override ShippingAddress GetAddress(string name)
        {
            return new(
                street: "567 8th Ave.",
                city: "Some Place",
                state: "YY",
                zip: "12345-7890",
                deliveryInstructions: "Ring Doorbell");
        }
    }
}
