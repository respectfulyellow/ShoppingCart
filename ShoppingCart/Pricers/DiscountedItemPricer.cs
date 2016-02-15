namespace ShoppingCart.Pricers
{
    public class DiscountedItemPricer : IPricer
    {
        private char _sku;
        private int _priceForOne;
        private int _quantityDiscount;
        private int _discountPrice;
        private int _quantityPurchased;

        public DiscountedItemPricer(char sku, int priceForOne, int quantityDiscount, int discountPrice)
        {
            _sku = sku;
            _priceForOne = priceForOne;
            _quantityDiscount = quantityDiscount;
            _discountPrice = discountPrice;
            _quantityPurchased = 0;
        }

        public int TotalPrice => _quantityPurchased*_priceForOne;
        
        public void AddItem()
        {
            _quantityPurchased++;
        }
    }
}
