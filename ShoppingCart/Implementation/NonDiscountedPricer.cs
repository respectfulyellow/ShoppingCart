namespace ShoppingCart.Implementation
{
    public class NonDiscountedPricer : IPricer
    {
        private readonly int _price;

        public NonDiscountedPricer(int price, char sku)
        {
            _price = price;
            Sku = sku;
        }

        public int TotalPrice(int quantityPurchased)
        {
            return quantityPurchased * _price;
        }

        public char Sku { get; }
    }
}
