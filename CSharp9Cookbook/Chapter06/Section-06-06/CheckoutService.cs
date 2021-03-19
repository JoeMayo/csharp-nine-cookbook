using System.Threading.Tasks;

namespace Section_06_06
{
    public class CheckoutService
    {
        public async Task<string> StartAsync()
        {
            await ValidateAddressAsync().ConfigureAwait(false);
            await ValidateCreditAsync().ConfigureAwait(false);
            await GetShoppingCartAsync().ConfigureAwait(false);
            await FinalizeCheckoutAsync().ConfigureAwait(false);

            return "Checkout Complete";
        }

        async Task<bool> ValidateAddressAsync()
        {
            bool result = true;
            return await Task.FromResult(result);
        }

        async Task<bool> ValidateCreditAsync()
        {
            bool result = true;
            return await Task.FromResult(result);
        }

        async Task<bool> GetShoppingCartAsync()
        {
            bool result = true;
            return await Task.FromResult(result);
        }

        async Task FinalizeCheckoutAsync()
        {
            await Task.CompletedTask;
        }
    }
}
