namespace ShoppingCart
{
    public interface IItemCostCalculator
    {
        int GetPrice(char sku, int quantity);
    }
}
