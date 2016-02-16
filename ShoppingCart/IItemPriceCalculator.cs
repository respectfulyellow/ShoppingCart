namespace ShoppingCart
{
    public interface IItemPriceCalculator
    {
        int GetPrice(char sku, int quantity);
    }
}
