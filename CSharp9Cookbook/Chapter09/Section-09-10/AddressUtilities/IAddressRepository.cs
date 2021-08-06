using System.Collections.Generic;

namespace AddressUtilities
{
    public interface IAddressRepository
    {
        List<Address> GetAddresses();
    }
}