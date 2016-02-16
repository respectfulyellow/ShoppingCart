namespace ShoppingCart.Pricers
{
    public class NonDiscountedPricer : IPricer
    {
        private readonly int _price;

        public NonDiscountedPricer(int price)
        {
            _price = price;
        }

        public int TotalPrice(int quantityPurchased)
        {
            return 0;
        }
    }
}
