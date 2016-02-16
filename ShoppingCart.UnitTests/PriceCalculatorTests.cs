using NUnit.Framework;
using ShoppingCart.ItemCounter;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ShoppingCart.UnitTests
{
    class PriceCalculatorTests
    {
        private IItemCounter _itemCounter;

        [SetUp]
        public void SetUp()
        {
            _itemCounter = Mock.Create<IItemCounter>();
        }

        public PriceCalculator CreatePriceCalculator()
        {
            var priceCalculator = new PriceCalculator(_itemCounter);
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
        public void Should_Call_Pricer_TotalPrice_ForItemCount()
        {
            
        }
    }
}
