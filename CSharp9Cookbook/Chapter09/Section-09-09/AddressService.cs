using System.Collections.Generic;

namespace Section_09_09
{
    public  class AddressService
    {
        public IEnumerable<Address[]> GetAddresses(int perPage)
        {
            Address[] addresses = GetAddresses();

            for (int i = 0, j = i+perPage; 
                 i < addresses.Length; 
                 i+=perPage, j+=perPage)
            {
                yield return addresses[i..j];
            }
        }

        Address[] GetAddresses()
        {
            int count = 15;
            List<Address> addresses = new();

            for (int i = 0; i < count; i++)
            {
                string streetSuffix =
                    i switch
                    {
                        0 => "st",
                        1 => "nd",
                        2 => "rd",
                        _ => "th"
                    };

                addresses.Add(
                    new(
                    Street: $"{i+100} {i+1}{streetSuffix} St.",
                    City: "My Place",
                    State: "ZZ",
                    Zip: "12345-7890"));
            }

            return addresses.ToArray();
        }
    }
}
