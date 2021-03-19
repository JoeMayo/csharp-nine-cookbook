using System.Threading.Tasks;

namespace Section_06_02
{
    public class CheckoutService
    {
        public async ValueTask<string> StartAsync()
        {
            await ValidateAddressAsync();
            await ValidateCreditAsync();
            await GetShoppingCartAsync();
            await FinalizeCheckoutAsync();

            return "Checkout Complete";
        }

        async ValueTask ValidateAddressAsync()
        {
            // perform address validation
        }

        async ValueTask ValidateCreditAsync()
        {
            // ensure credit is good
        }

        async ValueTask GetShoppingCartAsync()
        {
            // get contents of shopping cart
        }

        async ValueTask FinalizeCheckoutAsync()
        {
            // complete checkout transaction
        }
    }
}
