using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Implementation
{
    public class ItemCounter : IItemCounter
    {
        public IEnumerable<ItemCount> CountItems(string skus)
        {
            return skus.GroupBy(c => c)
                .Select(g => new ItemCount(g.Key, g.Count()));
        }
    }
}
