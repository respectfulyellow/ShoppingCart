namespace ShoppingCart.Pricers
{
    public interface IPricer
    {
        int TotalPrice(int quantityPurchased);
    }
}