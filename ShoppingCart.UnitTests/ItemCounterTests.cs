using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using ShoppingCart.Implementation;

namespace ShoppingCart.UnitTests
{
    [TestFixture]
    public class ItemCounterTests
    {
        [Test]
        public void When_No_Items_Values_Should_Be_Empty()
        {
            var itemCounter = new ItemCounter();
            itemCounter.CountItems("").Should().BeEmpty();
        }

        [Test]
        public void WhenAddOneItem_Values_Should_Contain_Item_With_Sku_And_CountOfOne()
        {
            var itemCounter =new ItemCounter();

            var itemCounts = itemCounter.CountItems("A");

            var expectedItemCounts = new List<ItemCount>
            {
                new ItemCount('A', 1)
            };

            itemCounts.Should().BeEquivalentTo(expectedItemCounts);
        }

        [Test]
        public void WhenAddTwoSameItem_Values_Should_Contain_Item_With_Sku_And_CountOfTwo()
        {
            var itemCounter = new ItemCounter();

            var itemCounts = itemCounter.CountItems("AA");

            var expectedItemCounts = new List<ItemCount>
            {
                new ItemCount('A', 2)
            };

            itemCounts.Should().BeEquivalentTo(expectedItemCounts);
        }

        [Test]
        public void WhenAddTwoDifferentItem_Values_Should_Contain_BothSkusWithCountOfOne()
        {
            var itemCounter = new ItemCounter();

            var itemCounts = itemCounter.CountItems("AB");

            var expectedResults = new List<ItemCount>
            {
                new ItemCount('A', 1),
                new ItemCount('B', 1)
            };

            itemCounts.Should().BeEquivalentTo(expectedResults);
        }

    }
}
