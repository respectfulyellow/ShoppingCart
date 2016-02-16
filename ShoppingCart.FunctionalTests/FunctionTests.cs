using System.Collections;
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
            _kernel.Bind<IPricerDataService>().To<PricerDataService>()
                .InSingletonScope();
        }

        private static IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData("").Returns(0);
                yield return new TestCaseData("A").Returns(50);
                yield return new TestCaseData("AB").Returns(80);
                yield return new TestCaseData("CDBA").Returns(115);
                yield return new TestCaseData("AA").Returns(100);
                yield return new TestCaseData("AAA").Returns(130);
                yield return new TestCaseData("AAABB").Returns(175);
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public int TestScenerio(string skus)
        {
            var totalCostCalculator = _kernel.Get<TotalCostCalculator>();
            var totalCost = totalCostCalculator.Calculate(skus);

            return totalCost;
        }

    }
}
