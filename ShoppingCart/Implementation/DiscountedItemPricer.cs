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
            DiscountedTotal(quantityPurchased)
            + NonDiscountedTotal(quantityPurchased);

        private int NonDiscountedTotal(int quantityPurchased)
        {
            return quantityPurchased%_quantityDiscount*_priceForOne;
        }

        private int DiscountedTotal(int quantityPurchased)
        {
            return _discountPrice*(quantityPurchased/_quantityDiscount);
        }

        public char Sku { get; }
    }
}
