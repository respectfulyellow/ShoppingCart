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
            discountedItemPricer.TotalPrice(0).Should().Be(0);
        }

        [Test]
        public void WhenHas_OneItem_AndQuantityDiscountGreaterThanOne_TotalPrice_Should_PriceForOne()
        {
            var discountedItemPricer = new DiscountedItemPricer('A', 50, 5, 130);
            discountedItemPricer.TotalPrice(1).Should().Be(50);
        }

        [Test]
        public void WhenHas_OneItemLessThanQuantityDiscount_TotalPrice_Should_PriceForOneTimesQuantity()
        {
            var discountedItemPricer = new DiscountedItemPricer('A', 50, 5, 130);
            discountedItemPricer.TotalPrice(4).Should().Be(200);
        }

        [Test]
        public void When_HasExactlyQuantityDiscount_TotalPrice_ShouldBe_DiscountPrice()
        {
            var discountedItemPricer = new DiscountedItemPricer('A', 50, 5, 130);

            discountedItemPricer.TotalPrice(5).Should().Be(130);
        }
    }
}
