using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ItemCounter
    {
        private readonly IDictionary<char, int> _items;
        public IEnumerable<ItemCount> Values => _items.Select(i => new ItemCount(i.Key, i.Value));

        public ItemCounter()
        {
            _items = new Dictionary<char, int>();
        }

        public void AddItems(string skus)
        {
            foreach (var sku in skus)
            {
                AddItem(sku);
            }
        }

        private void AddItem(char sku)
        {
            int count;
            if (_items.TryGetValue(sku, out count))
            {
                _items[sku]++;
            }
            else
            {
                _items[sku] = 1;
            }
        }
    }
}
