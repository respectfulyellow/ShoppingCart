using ShoppingCart.ItemCounter;

namespace ShoppingCart
{
    public class PriceCalculator
    {
        private readonly IItemCounter _itemCounter;
        private readonly IItemPriceCalculator _itemPriceCalculator;

        public PriceCalculator(IItemCounter itemCounter, IItemPriceCalculator itemPriceCalculator)
        {
            _itemCounter = itemCounter;
            _itemPriceCalculator = itemPriceCalculator;
        }

        public void Calculate(string skus)
        {
            _itemCounter.AddItems(skus);
            foreach (var itemCount in _itemCounter.Values)
            {
                _itemPriceCalculator.GetPrice(itemCount.Sku, itemCount.Count);
            }
        }
    }
}
