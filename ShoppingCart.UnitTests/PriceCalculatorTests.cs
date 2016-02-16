using System.Collections.Generic;
using NUnit.Framework;
using ShoppingCart.ItemCounter;
using ShoppingCart.Pricers;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ShoppingCart.UnitTests
{
    class PriceCalculatorTests
    {
        private IItemCounter _itemCounter;
        private IItemPriceCalculator _itemPriceCalculator;

        [SetUp]
        public void SetUp()
        {
            _itemCounter = Mock.Create<IItemCounter>();
            _itemPriceCalculator = Mock.Create<IItemPriceCalculator>();
        }

        public PriceCalculator CreatePriceCalculator()
        {
            var priceCalculator = new PriceCalculator(_itemCounter, _itemPriceCalculator);
            return priceCalculator;
        }

        [Test]
        public void Should_AddItems()
        {
            const string skus = "ABCD";
            var priceCalculator = CreatePriceCalculator();
            _itemCounter.Arrange(i => i.AddItems(skus)).MustBeCalled();
            
            priceCalculator.Calculate(skus);

            _itemCounter.Assert();
        }

        [Test]
        public void Should_Call_Pricer_TotalPrice_ForEachItemCount()
        {
            var priceCalculator = CreatePriceCalculator();
            var itemCounts = new List<ItemCount>
            {
                new ItemCount('A', 5),
                new ItemCount('B', 10)
            };
            _itemCounter.Arrange(ic => ic.Values).Returns(itemCounts);
            _itemPriceCalculator.Arrange(ipc => ipc.GetPrice('A', 5)).MustBeCalled();
            _itemPriceCalculator.Arrange(ipc => ipc.GetPrice('B', 10)).MustBeCalled();

            priceCalculator.Calculate("AB");

            _itemPriceCalculator.Assert();
        }
    }
}
