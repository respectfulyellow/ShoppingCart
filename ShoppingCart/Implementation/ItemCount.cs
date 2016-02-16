namespace ShoppingCart.Implementation
{
    public class ItemCount
    {
        protected bool Equals(ItemCount other)
        {
            return Sku == other.Sku && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ItemCount) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Sku.GetHashCode()*397) ^ Count;
            }
        }

        public char Sku { get; }
        public int Count { get; set; }

        public ItemCount(char sku, int count)
        {
            Sku = sku;
            Count = count;
        }
    }
}