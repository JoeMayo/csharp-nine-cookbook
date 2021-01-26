using System.Collections.Generic;

namespace Section_04_01
{
    public class InMemoryContext
    {
        List<SalesPerson> salesPeople =
            new List<SalesPerson>
            {
                new SalesPerson
                {
                    ID = 1,
                    Address = "123 1st Street",
                    City = "First City",
                    Name = "First Person",
                    PostalCode = "45678",
                    Region = "Region #1"
                },
                new SalesPerson
                {
                    ID = 2,
                    Address = "234 2nd Street",
                    City = "Second City",
                    Name = "Second Person",
                    PostalCode = "56789",
                    Region = "Region #2"
                },
                new SalesPerson
                {
                    ID = 3,
                    Address = "345 3rd Street",
                    City = "Third City",
                    Name = "Third Person",
                    PostalCode = "67890",
                    Region = "Region #3"
                },
            };

        public List<SalesPerson> SalesPeople
        {
            get
            {
                return salesPeople;
            }
        }
    }
}
