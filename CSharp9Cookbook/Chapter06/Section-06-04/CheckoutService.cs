using System.Threading.Tasks;

namespace Section_06_04
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

        async Task ValidateAddressAsync()
        {
            // perform address validation
        }

        async Task ValidateCreditAsync()
        {
            // ensure credit is good
        }

        async Task GetShoppingCartAsync()
        {
            // get contents of shopping cart
        }

        async Task FinalizeCheckoutAsync()
        {
            // complete checkout transaction
        }
    }
}
