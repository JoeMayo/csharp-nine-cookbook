namespace OrdersLibrary
{
    public class Order
    {
        public decimal CalculateDiscount(
            CustomerType custType, decimal amount)
        {
            decimal discount;

            switch (custType)
            {
                case CustomerType.Silver:
                    discount = amount * 1.05m;
                    break;
                case CustomerType.Gold:
                    discount = amount * 1.10m;
                    break;
                case CustomerType.Bronze:
                default:
                    discount = amount;
                    break;
            }

            return discount;
        }
    }
}
