using System.Collections.Generic;
using ShoppingCart.Implementation;

namespace ShoppingCart.FunctionalTests
{
    public class PricerDataService : IPricerDataService
    {
        public ICollection<IPricer> GetPricers()
        {
            return new List<IPricer>
            {
                new DiscountedItemPricer(50, 3, 130, 'A'),
                new DiscountedItemPricer(30, 2, 45, 'B'),
                new NonDiscountedPricer(20, 'C'),
                new NonDiscountedPricer(15, 'D')
            };
        }
    }
}
