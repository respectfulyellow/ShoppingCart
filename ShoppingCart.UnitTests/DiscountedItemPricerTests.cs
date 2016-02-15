using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.Pricers;

namespace ShoppingCart.UnitTests
{
    [TestFixture]
    class DiscountedItemPricerTests
    {
        [Test]
        public void WhenHasNoItems_Should_Return_0()
        {
            var discountedItemPricer = new DiscountedItemPricer('A', 50, 2, 130);
            discountedItemPricer.Price.Should().Be(0);
        }
    }
}
