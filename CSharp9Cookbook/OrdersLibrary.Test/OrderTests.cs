using Xunit;

namespace OrdersLibrary.Test
{
    public class OrderTests
    {
        [Fact]
        public void CalculateDiscount_WithBronzeCustomer_GivesNoDiscount()
        {
            const decimal ExpectedDiscount = 5.00m;

            decimal actualDiscount = 
                new Order().CalculateDiscount(CustomerType.Bronze, 5.00m);

            Assert.Equal(ExpectedDiscount, actualDiscount);
        }

        [Fact]
        public void CalculateDiscount_WithSilverCustomer_GivesFivePercentDiscount()
        {
            const decimal ExpectedDiscount = 5.25m;

            decimal actualDiscount =
                new Order().CalculateDiscount(CustomerType.Silver, 5.00m);

            Assert.Equal(ExpectedDiscount, actualDiscount);
        }

        [Fact]
        public void CalculateDiscount_WithGoldCustomer_GivesTenPercentDiscount()
        {
            const decimal ExpectedDiscount = 5.50m;

            decimal actualDiscount =
                new Order().CalculateDiscount(CustomerType.Gold, 5.00m);

            Assert.Equal(ExpectedDiscount, actualDiscount);
        }

    }
}
