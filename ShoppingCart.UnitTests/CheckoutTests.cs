using NUnit.Framework;
using ShoppingCart.ItemCounter;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ShoppingCart.UnitTests
{
    class CheckoutTests
    {
        [Test]
        public void Should_AddItems()
        {
            var skus = "ABCD";

            var itemCounter = Mock.Create<IItemCounter>();
            itemCounter.Arrange(i => i.AddItems(skus)).MustBeCalled();
            var checkout = new PriceCalculator(itemCounter);

            checkout.Calculate(skus);

            itemCounter.Assert();
        }
    }
}
