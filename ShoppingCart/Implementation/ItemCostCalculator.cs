using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Implementation
{
    public class ItemCostCalculator : IItemCostCalculator
    {
        private readonly IDictionary<char, IPricer> _pricers;  

        public ItemCostCalculator(IPricerDataService pricerDataService)
        {
            _pricers = pricerDataService.GetPricers().ToDictionary(p => p.Sku);
        }

        public int GetPrice(char sku, int quantity)
        {
            return _pricers[sku].TotalPrice(quantity);
        }
    }
}