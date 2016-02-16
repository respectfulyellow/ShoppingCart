using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.Implementation;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ShoppingCart.UnitTests
{
    [TestFixture]
    public class ItemCostCalculatorTests
    {
        [Test]
        public void Should_Use_Correct_Pricer_To_Determine_Price()
        {
            const int quantityPurchased = 10;
            var pricer1 = CreatePricer(quantityPurchased, 'A', 100);
            var pricer2 = CreatePricer(quantityPurchased, 'B', 200);
            var pricers = new List<IPricer>
            {
                pricer1,
                pricer2
            };
            var pricerDataService = Mock.Create<IPricerDataService>();
            pricerDataService.Arrange(pds => pds.GetPricers())
                .Returns(pricers);

            var itemCostCalculator = new ItemCostCalculator(pricerDataService);
            var itemCost = itemCostCalculator.GetPrice('B', quantityPurchased);

            itemCost.Should().Be(200);
        }

        private static IPricer CreatePricer(int quantityPurchased, char sku, int cost)
        {
            var pricer1 = Mock.Create<IPricer>();
            pricer1.Arrange(p => p.Sku).Returns(sku);
            pricer1.Arrange(p => p.TotalPrice(quantityPurchased)).Returns(cost);
            return pricer1;
        }
    }
}
