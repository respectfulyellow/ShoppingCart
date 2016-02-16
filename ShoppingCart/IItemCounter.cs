using System.Collections.Generic;
using ShoppingCart.Implementation;

namespace ShoppingCart
{
    public interface IItemCounter
    {
        IEnumerable<ItemCount> CountItems(string skus);
    }
}