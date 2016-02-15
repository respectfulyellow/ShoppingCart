namespace ShoppingCart.Pricers
{
    public class DiscountedItemPricer : IPricer
    {
        private char _sku;
        private int _priceForOne;
        private int _quantityDiscount;
        private int _discountPrice;

        public DiscountedItemPricer(char sku, int priceForOne, int quantityDiscount, int discountPrice)
        {
            _sku = sku;
            _priceForOne = priceForOne;
            _quantityDiscount = quantityDiscount;
            _discountPrice = discountPrice;
        }

        public int Price => 0;
    }
}
