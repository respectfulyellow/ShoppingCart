using FluentAssertions;
using NUnit.Framework;

namespace ShoppingCart.UnitTests
{
    [TestFixture]
    public class ItemCounterTests
    {
        [Test]
        public void When_No_Items_Results_Should_Be_Empty()
        {
            var itemCounter = new ItemCounter();
            itemCounter.Values.Should().BeEmpty();
        }
    }
}
