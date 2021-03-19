using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section_06_03
{
    public class CheckoutStream
    {
        public async IAsyncEnumerable<CheckoutRequest> GetRequestsAsync()
        {
            while (true)
            {
                IEnumerable<CheckoutRequest> requests =
                    await GetNextBatchAsync();

                foreach (var request in requests)
                    yield return request;

                await Task.Delay(1000);
            }
        }

        async Task<IEnumerable<CheckoutRequest>> GetNextBatchAsync()
        {
            return new List<CheckoutRequest>
            {
                new CheckoutRequest
                {
                    ShoppingCartID = Guid.NewGuid(),
                    Address = "123 4th St",
                    Card = "1234 5678 9012 3456",
                    Name = "First Card Name"
                },
                new CheckoutRequest
                {
                    ShoppingCartID = Guid.NewGuid(),
                    Address = "789 1st Ave",
                    Card = "2345 6789 0123 4567",
                    Name = "Second Card Name"
                },
                new CheckoutRequest
                {
                    ShoppingCartID = Guid.NewGuid(),
                    Address = "123 4th St",
                    Card = "1234 5678 9012 3456",
                    Name = "First Card Name"
                },
            };
        }
    }
}
