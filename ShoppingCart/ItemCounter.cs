using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ItemCounter
    {
        private readonly List<ItemCount> _items;
        public IEnumerable<ItemCount> Values => _items;

        public ItemCounter()
        {
            _items = new List<ItemCount>();
        }

        public void AddItems(string s)
        {
            _items.Add(new ItemCount(s[0], 1));
        }
    }
}
