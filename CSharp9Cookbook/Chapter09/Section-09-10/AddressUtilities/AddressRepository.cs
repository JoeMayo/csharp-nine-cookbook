using System.Collections.Generic;

namespace AddressUtilities
{
    public class AddressRepository : IAddressRepository
    {
        public List<Address> GetAddresses() => 
            new List<Address>
            {
                new (
                    Street: "123 4th St.",
                    City: "My Place",
                    State: "ZZ",
                    Zip: "12345-7890"),
                new (
                    Street: "567 8th Ave.",
                    City: "Some Place",
                    State: "YY",
                    Zip: "12345-7890"),
                new (
                    Street: "567 8th Ave.",
                    City: "Some Place",
                    State: "YY",
                    Zip: "12345-7890")
            };
    }
}
