using System.Collections.Generic;
using NUnit.Framework;
using ShoppingCart.ItemCounter;
using ShoppingCart.Pricers;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ShoppingCart.UnitTests
{
    class PriceCalcuatorTests
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

        [Test]
        public void Should_Call_CorrectPricer_With_Count()
        {
            var skus = "A";

            var itemCounter = Mock.Create<IItemCounter>();
            var aPricer = Mock.Create<IPricer>();
            aPricer.Arrange(ap => ap.TotalPrice(1)).MustBeCalled();

            var pricers = new List<IPricer> {aPricer};

            var aItemCount = new ItemCount('a', 1);
            var counts = new List<ItemCount>
            {
                aItemCount
            };
            itemCounter.Arrange(i => i.AddItems(skus)).Returns(counts);
            var checkout = new PriceCalculator(itemCounter, pricers);

            checkout.Calculate(skus);

            aPricer.Assert();
        }

    }
}
