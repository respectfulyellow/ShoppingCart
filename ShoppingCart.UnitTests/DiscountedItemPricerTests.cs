using NUnit.Framework;

namespace ShoppingCart.UnitTests
{
    [TestFixture]
    class DiscountedItemPricerTests
    {
        [Test]
        public void WhenHasNoItems_Should_Return_0()
        {
            var discountedItemPricer = new DisountedItemPricer();
        }
    }
}
