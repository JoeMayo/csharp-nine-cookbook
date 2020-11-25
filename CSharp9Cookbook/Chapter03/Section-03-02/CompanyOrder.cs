namespace Section_03_02
{
    public class CompanyOrder : IOrder
    {
        decimal total = 25.00m;

        public string PrintOrder()
        {
            return "Company Order Details";
        }

        public decimal GetRewards()
        {
            return total * 0.01m;
        }
    }
}
