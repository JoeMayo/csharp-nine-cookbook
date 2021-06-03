using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_09_02
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

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
