using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.ItemCounter;
using ShoppingCart.Pricers;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ShoppingCart.UnitTests
{
    class CostCalculatorTests
    {
        private IItemCounter _itemCounter;
        private IItemCostCalculator _itemCostCalculator;

        [SetUp]
        public void SetUp()
        {
            _itemCounter = Mock.Create<IItemCounter>();
            _itemCostCalculator = Mock.Create<IItemCostCalculator>();
        }

        public TotalCostCalculator CreateTotalCostCalculator()
        {
            var totalCostCalculator = new TotalCostCalculator(_itemCounter, _itemCostCalculator);
            return totalCostCalculator;
        }

        [Test]
        public void Should_AddItems()
        {
            const string skus = "ABCD";
            var totalCostCalculator = CreateTotalCostCalculator();
            _itemCounter.Arrange(i => i.AddItems(skus)).MustBeCalled();
            
            totalCostCalculator.Calculate(skus);

            _itemCounter.Assert();
        }

        [Test]
        public void Should_Call_ItemPriceCalculator_GetPrice_ForEachItemCount()
        {
            var totalCostCalculator = CreateTotalCostCalculator();
            var itemCounts = new List<ItemCount>
            {
                new ItemCount('A', 5),
                new ItemCount('B', 10)
            };
            _itemCounter.Arrange(ic => ic.Values).Returns(itemCounts);
            _itemCostCalculator.Arrange(ipc => ipc.GetPrice('A', 5)).MustBeCalled();
            _itemCostCalculator.Arrange(ipc => ipc.GetPrice('B', 10)).MustBeCalled();

            totalCostCalculator.Calculate("AB");

            _itemCostCalculator.Assert();
        }

        [Test]
        public void Should_Return_SumOfItemPriceCalculator_GetPrices()
        {
            var totalCostCalculator = CreateTotalCostCalculator();
            var itemCounts = new List<ItemCount>
            {
                new ItemCount('A', 5),
                new ItemCount('B', 10)
            };
            _itemCounter.Arrange(ic => ic.Values).Returns(itemCounts);
            _itemCostCalculator.Arrange(ipc => ipc.GetPrice('A', 5)).Returns(50);
            _itemCostCalculator.Arrange(ipc => ipc.GetPrice('B', 10)).Returns(75);

            var totalPrice = totalCostCalculator.Calculate("AB");

            totalPrice.Should().Be(125);
        }

    }
}
