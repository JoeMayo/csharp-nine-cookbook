using System.Threading.Tasks;

namespace Section_06_01
{
    public class CheckoutService
    {
        public async Task<string> StartAsync()
        {
            await ValidateAddressAsync();
            await ValidateCreditAsync();
            await GetShoppingCartAsync();
            await FinalizeCheckoutAsync();

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
