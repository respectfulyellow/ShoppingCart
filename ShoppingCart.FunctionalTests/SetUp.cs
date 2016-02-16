using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ninject;
using NUnit.Framework;
using Ninject.Extensions.Conventions;
using ShoppingCart.Implementation;

namespace ShoppingCart.FunctionalTests
{
    [TestFixture]
    public class FunctionTests
    {
        private StandardKernel _kernel;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _kernel = new StandardKernel();
            _kernel.Bind(x => x.FromAssemblyContaining<TotalCostCalculator>()
                .SelectAllClasses()
                .BindDefaultInterface().Configure(c => c.InSingletonScope()));
        }

        [Test]
        public void Test_Empty()
        {
            var totalCostCalculator = _kernel.Get<TotalCostCalculator>();
            var totalCost = totalCostCalculator.Calculate("");
            totalCost.Should().Be(0);
        }

        [Test]
        public void Test_A()
        {
            var totalCostCalculator = _kernel.Get<TotalCostCalculator>();
            var totalCost = totalCostCalculator.Calculate("A");
            totalCost.Should().Be(50);
        }
    }
}
