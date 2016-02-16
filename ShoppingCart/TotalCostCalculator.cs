using ShoppingCart.ItemCounter;

namespace ShoppingCart
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
            _itemCounter.AddItems(skus);
            var totalCost = 0;
            foreach (var itemCount in _itemCounter.Values)
            {
                var itemCost = _itemCostCalculator.GetPrice(itemCount.Sku, itemCount.Count);
                totalCost += itemCost;
            }

            return totalCost;
        }
    }
}
