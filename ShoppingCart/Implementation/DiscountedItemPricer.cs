namespace ShoppingCart.Implementation
{
    public class DiscountedItemPricer : IPricer
    {
        private readonly int _priceForOne;
        private readonly int _quantityDiscount;
        private readonly int _discountPrice;

        public DiscountedItemPricer(int priceForOne, int quantityDiscount, int discountPrice, char sku)
        {
            _priceForOne = priceForOne;
            _quantityDiscount = quantityDiscount;
            _discountPrice = discountPrice;
            Sku = sku;
        }

        public int TotalPrice(int quantityPurchased) =>
            _discountPrice*(quantityPurchased/_quantityDiscount)
            + (quantityPurchased%_quantityDiscount)*_priceForOne;

        public char Sku { get; }
    }
}
