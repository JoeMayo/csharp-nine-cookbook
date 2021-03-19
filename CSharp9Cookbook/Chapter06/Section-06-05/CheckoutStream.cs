using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section_06_05
{
    public class CheckoutStream
    {
        public async IAsyncEnumerable<CheckoutRequest>
            GetRequestsAsync(IProgress<CheckoutRequestProgress> progress)
        {
            int total = 0;

            while (true)
            {
                List<CheckoutRequest> requests =
                    await GetNextBatchAsync().ConfigureAwait(false);

                total += requests.Count;

                foreach (var request in requests)
                    yield return request;

                progress.Report(
                    new CheckoutRequestProgress
                    {
                        Total = total,
                        Message = "New Batch of Checkout Requests"
                    });

                await Task.Delay(1000).ConfigureAwait(false);
            }
        }

        async Task<List<CheckoutRequest>> GetNextBatchAsync()
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
