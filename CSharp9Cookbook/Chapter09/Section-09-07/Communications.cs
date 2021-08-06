namespace Section_09_07
{
    class Communications : DeliveryBase
    {
        public override MailingAddress GetAddress(string name)
        {
            return new(
                Street: "567 8th Ave.",
                City: "Some Place",
                State: "YY",
                Zip: "12345-7890",
                Email: "me@example.com",
                PreferEmail: true);
        }
    }
}
