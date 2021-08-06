namespace Section_09_03
{
    public class Address
    {
        public Address() { }

        public Address(
            string street, 
            string city, 
            string state, 
            string zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Zip { get; init; }
    }
}
