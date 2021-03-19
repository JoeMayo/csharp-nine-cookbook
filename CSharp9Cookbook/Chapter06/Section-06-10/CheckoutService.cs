using System.Threading.Tasks;

namespace Section_06_10
{
    public class CheckoutService
    {
        public async ValueTask<string> StartAsync(CheckoutRequest request)
        {
            return await Task.FromResult(
                $"Checkout Complete for Shopping " +
                $"Basket: {request.ShoppingCartID}");
        }
    }
}
