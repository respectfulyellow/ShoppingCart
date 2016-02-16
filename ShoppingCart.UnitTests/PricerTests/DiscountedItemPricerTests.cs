using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.Implementation;

namespace ShoppingCart.UnitTests.PricerTests
{
    [TestFixture]
    public class DiscountedItemPricerTests
    {
        public DiscountedItemPricer CreateDiscountedItemPricer()
        {
            return new DiscountedItemPricer(50, 5, 130, 'A');
        }

        [Test]
        public void WhenHasNoItems_Should_Return_0()
        {
            var discountedItemPricer = CreateDiscountedItemPricer();
            discountedItemPricer.TotalPrice(0).Should().Be(0);
        }

        [Test]
        public void WhenHas_OneItem_AndQuantityDiscountGreaterThanOne_TotalPrice_Should_PriceForOne()
        {
            var discountedItemPricer = CreateDiscountedItemPricer();
            discountedItemPricer.TotalPrice(1).Should().Be(50);
        }

        [Test]
        public void WhenHas_OneItemLessThanQuantityDiscount_TotalPrice_Should_PriceForOneTimesQuantity()
        {
            var discountedItemPricer = CreateDiscountedItemPricer();
            discountedItemPricer.TotalPrice(4).Should().Be(200);
        }

        [Test]
        public void When_HasExactlyQuantityDiscount_TotalPrice_ShouldBe_DiscountPrice()
        {
            var discountedItemPricer = CreateDiscountedItemPricer();

            discountedItemPricer.TotalPrice(5).Should().Be(130);
        }

        [Test]
        public void When_HasTwoTimesQuantityDiscount_TotalPrice_ShouldBe_DiscountPriceTimesTwo()
        {
            var discountedItemPricer = CreateDiscountedItemPricer();

            discountedItemPricer.TotalPrice(10).Should().Be(260);
        }

        [Test]
        public void When_HasQuantityDiscountPlusOne_TotalPrice_ShouldBe_DiscountPricePlusPriceForOne()
        {
            var discountedItemPricer = CreateDiscountedItemPricer();

            discountedItemPricer.TotalPrice(6).Should().Be(180);
        }

        [Test]
        public void When_HasQuantityDiscountPlusOneLessThanQuantityDiscount_TotalPrice_ShouldBe_DiscountPricePlusPriceForOneTimesQuantityDiscountMinusOne()
        {
            var discountedItemPricer = CreateDiscountedItemPricer();

            discountedItemPricer.TotalPrice(9).Should().Be(330);
        }

    }
}
