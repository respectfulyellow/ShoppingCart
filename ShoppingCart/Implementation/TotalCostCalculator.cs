using System.Linq;

namespace ShoppingCart.Implementation
{
    public class TotalCostCalculator
    {
        private readonly IItemCounter _itemCounter;
        private readonly IItemCostCalculator _itemCostCalculator;

        public TotalCostCalculator(IItemCounter itemCounter, IItemCostCalculator itemCostCalculator)
        {
            _itemCounter = itemCounter;
            _itemCostCalculator = itemCostCalculator;
        }

        public int Calculate(string skus)
        {
            return _itemCounter.CountItems(skus)
                .Sum(itemCount => _itemCostCalculator.GetPrice(itemCount.Sku, itemCount.Count));
        }
    }
}
