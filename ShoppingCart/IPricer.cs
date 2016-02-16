namespace ShoppingCart
{
    public interface IPricer
    {
        int TotalPrice(int quantityPurchased);
        char Sku { get; }
    }
}