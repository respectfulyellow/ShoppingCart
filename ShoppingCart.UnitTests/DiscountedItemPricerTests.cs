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
            discountedItemPricer.TotalPrice.Should().Be(0);
        }

        [Test]
        public void WhenHas_OneItem_AndQuantityDiscountGreaterThanOne_TotalPrice_Should_PriceForOne()
        {
            var discountedItemPricer = new DiscountedItemPricer('A', 50, 5, 130);
            discountedItemPricer.AddItem();
            discountedItemPricer.TotalPrice.Should().Be(50);
        }

        [Test]
        public void WhenHas_OneItemLessThanQuantityDiscount_TotalPrice_Should_PriceForOneTimesQuantity()
        {
            var discountedItemPricer = new DiscountedItemPricer('A', 50, 5, 130);
            discountedItemPricer.AddItem();
            discountedItemPricer.AddItem();
            discountedItemPricer.AddItem();
            discountedItemPricer.AddItem();
            discountedItemPricer.TotalPrice.Should().Be(200);
        }

    }
}
