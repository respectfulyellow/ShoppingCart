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

        public void AddItems(string skus)
        {
            foreach (var sku in skus)
            {
                var item = _items.SingleOrDefault(s => s.Sku == sku);
                if (item != null)
                {
                    item.Count++;
                }
                else
                {
                    _items.Add(new ItemCount(sku, 1));
                }
            }
        }
    }
}
