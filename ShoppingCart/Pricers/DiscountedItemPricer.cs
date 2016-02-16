namespace ShoppingCart.Pricers
{
    public class DiscountedItemPricer : IPricer
    {
        private char _sku;
        private readonly int _priceForOne;
        private readonly int _quantityDiscount;
        private readonly int _discountPrice;

        public DiscountedItemPricer(char sku, int priceForOne, int quantityDiscount, int discountPrice)
        {
            _sku = sku;
            _priceForOne = priceForOne;
            _quantityDiscount = quantityDiscount;
            _discountPrice = discountPrice;
        }

        public int TotalPrice(int quantityPurchased) => quantityPurchased == _quantityDiscount
            ? _discountPrice
            : quantityPurchased*_priceForOne;
    }
}
