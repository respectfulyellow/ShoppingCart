using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.ItemCounter
{
    public class ItemCounter : IItemCounter
    {
        private string _items;

        public ItemCounter()
        {
            _items = "";
        }

        public IEnumerable<ItemCount> Values => _items.GroupBy(c => c)
            .Select(g => new ItemCount(g.Key, g.Count()));

        public void AddItems(string skus)
        {
            _items += skus;
        }

    }
}
