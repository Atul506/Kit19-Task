using ProductsModels;
using System.Collections.Generic;

namespace ProductsBLL
{
    public interface IProductsBL
    {
        List<Product> GetProducts(Product searchCriteria, string searchOption);
    }
}
