using ShoppingCart.ItemCounter;

namespace ShoppingCart
{
    public class PriceCalculator
    {
        private readonly IItemCounter _itemCounter;

        public PriceCalculator(IItemCounter itemCounter)
        {
            _itemCounter = itemCounter;
        }

        public void Calculate(string skus)
        {
            _itemCounter.AddItems(skus);
        }
    }
}
