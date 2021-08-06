using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace AddressUtilities
{
    public class AddressService
    {
        readonly IAddressRepository addressRep;

        public AddressService(IAddressRepository addressRep) => 
            this.addressRep = addressRep;

        public static AddressService Create() => 
            Initializer.Container.GetRequiredService<AddressService>();

        public List<Address> GetAddresses() =>
            (from address in addressRep.GetAddresses()
             select address)
            .Distinct()
            .ToList();
    }
}
