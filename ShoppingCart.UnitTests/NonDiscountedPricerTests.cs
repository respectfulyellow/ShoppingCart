﻿using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.Pricers;

namespace ShoppingCart.UnitTests
{
    [TestFixture]
    public class NonDiscountedPricerTests
    {
        [Test]
        public void When_Zero_Items_Purchased_TotalPrice_Should_Be_0()
        {
            var nonDiscountedPricer = new NonDiscountedPricer(30);
            nonDiscountedPricer.TotalPrice(0).Should().Be(0);
        }
    }
}
