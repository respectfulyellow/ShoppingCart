using System.Collections.Generic;

namespace ShoppingCart.ItemCounter
{
    public interface IItemCounter
    {
        IEnumerable<ItemCount> Values { get; }
        void AddItems(string skus);
    }
}