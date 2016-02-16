using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.Pricers;

namespace ShoppingCart.UnitTests.PricerTests
{
    [TestFixture]
    public class NonDiscountedPricerTests
    {
        [Test]
        public void When_Zero_Items_Purchased_TotalPrice_Should_Be_0()
        {
            var nonDiscountedPricer = new NonDiscountedPricer(30);
            nonDiscountedPricer.TotalPrice(0).Should().Be(0);
        }

        [Test]
        public void When_OneItems_Purchased_TotalPrice_Should_Be_Price()
        {
            var nonDiscountedPricer = new NonDiscountedPricer(30);
            nonDiscountedPricer.TotalPrice(1).Should().Be(30);
        }

        [Test]
        public void When_TenItems_Purchased_TotalPrice_Should_Be_PriceTimesTen()
        {
            var nonDiscountedPricer = new NonDiscountedPricer(30);
            nonDiscountedPricer.TotalPrice(10).Should().Be(300);
        }
    }
}
