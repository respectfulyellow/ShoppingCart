namespace ShoppingCart.Pricers
{
    public class DiscountedItemPricer : IPricer
    {
        private readonly int _priceForOne;
        private readonly int _quantityDiscount;
        private readonly int _discountPrice;

        public DiscountedItemPricer(int priceForOne, int quantityDiscount, int discountPrice)
        {
            _priceForOne = priceForOne;
            _quantityDiscount = quantityDiscount;
            _discountPrice = discountPrice;
        }

        public int TotalPrice(int quantityPurchased) =>
            _discountPrice*(quantityPurchased/_quantityDiscount)
            + (quantityPurchased%_quantityDiscount)*_priceForOne;
    }
}
