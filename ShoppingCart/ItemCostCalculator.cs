using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using ShoppingCart.Pricers;

namespace ShoppingCart
{
    public class ItemCostCalculator : IItemCostCalculator
    {
        private readonly IDictionary<char, IPricer> _pricers;  

        public ItemCostCalculator(ICollection<IPricer> pricers)
        {
            _pricers = pricers.ToDictionary(p => p.Sku);
        }

        public int GetPrice(char sku, int quantity)
        {
            return _pricers[sku].TotalPrice(quantity);
        }
    }
}