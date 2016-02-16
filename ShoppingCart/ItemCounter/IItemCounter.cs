using System.Collections.Generic;

namespace ShoppingCart.ItemCounter
{
    public interface IItemCounter
    {
        IEnumerable<ItemCount> CountItems(string skus);
    }
}