using FluentAssertions;
using NUnit.Framework;

namespace ShoppingCart.UnitTests
{
    [TestFixture]
    public class ItemCounterTests
    {
        [Test]
        public void When_No_Items_Values_Should_Be_Empty()
        {
            var itemCounter = new ItemCounter();
            itemCounter.Values.Should().BeEmpty();
        }

        [Test]
        public void WhenAddOneItem_Values_Should_Contain_Item_With_Sku_And_CountOfOne()
        {
            var itemCounter =new ItemCounter();

            itemCounter.AddItems("A");

            itemCounter.Values.Should().HaveCount(1);
            itemCounter.Values.Should().Contain(new ItemCount('A', 1));
        }

        [Test]
        public void WhenAddTwoSameItem_Values_Should_Contain_Item_With_Sku_And_CountOfTwo()
        {
            var itemCounter = new ItemCounter();

            itemCounter.AddItems("AA");

            itemCounter.Values.Should().HaveCount(1);
            itemCounter.Values.Should().Contain(new ItemCount('A', 2));
        }

    }
}
