using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Section_06_09
{
    public class CheckoutStream
    {
        CancellationToken cancelToken;

        public CheckoutStream(CancellationToken cancelToken)
        {
            this.cancelToken = cancelToken;
        }

        public async IAsyncEnumerable<CheckoutRequest> GetRequestsAsync(
            IProgress<CheckoutRequestProgress> progress)
        {
            int total = 0;

            while (true)
            {
                var requests = new List<CheckoutRequest>();

                try
                {
                    requests = await GetNextBatchAsync();
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                total += requests.Count;

                foreach (var request in requests)
                {
                    if (cancelToken.IsCancellationRequested)
                        break;

                    yield return request;
                }

                progress.Report(
                    new CheckoutRequestProgress
                    {
                        Total = total,
                        Message = "New Batch of Checkout Requests"
                    });


                if (cancelToken.IsCancellationRequested)
                    break;

                await Task.Delay(1000);
            }

            if (cancelToken.IsCancellationRequested)
                progress.Report(
                    new CheckoutRequestProgress
                    {
                        Total = total,
                        Message = "Process Cancelled!"
                    });
        }

        async Task<List<CheckoutRequest>> GetNextBatchAsync()
        {
            if (cancelToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var requests = new List<CheckoutRequest>
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

            return await Task.FromResult(requests);
        }
    }
}
