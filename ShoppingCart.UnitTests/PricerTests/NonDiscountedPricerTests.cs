using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.Implementation;

namespace ShoppingCart.UnitTests.PricerTests
{
    [TestFixture]
    public class NonDiscountedPricerTests
    {
        public NonDiscountedPricer CreateNonDiscountedPricer()
        {
            return new NonDiscountedPricer(30, 'Q');
        }
        [Test]
        public void When_Zero_Items_Purchased_TotalPrice_Should_Be_0()
        {
            var nonDiscountedPricer = CreateNonDiscountedPricer();;
            nonDiscountedPricer.TotalPrice(0).Should().Be(0);
        }

        [Test]
        public void When_OneItems_Purchased_TotalPrice_Should_Be_Price()
        {
            var nonDiscountedPricer = CreateNonDiscountedPricer();
            nonDiscountedPricer.TotalPrice(1).Should().Be(30);
        }

        [Test]
        public void When_TenItems_Purchased_TotalPrice_Should_Be_PriceTimesTen()
        {
            var nonDiscountedPricer = CreateNonDiscountedPricer();
            nonDiscountedPricer.TotalPrice(10).Should().Be(300);
        }
    }
}
