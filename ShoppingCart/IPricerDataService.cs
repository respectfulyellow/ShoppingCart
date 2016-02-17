    using System.Collections.Generic;

namespace ShoppingCart
{
    public interface IPricerDataService
    {
        ICollection<IPricer> GetPricers();
    }
}
