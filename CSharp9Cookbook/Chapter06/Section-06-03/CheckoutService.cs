using System.Threading.Tasks;

namespace Section_06_03
{
    public class CheckoutService
    {
        public async ValueTask<string> StartAsync(CheckoutRequest request)
        {
            return
                $"Checkout Complete for Shopping " +
                $"Basket: {request.ShoppingCartID}";
        }
    }
}
