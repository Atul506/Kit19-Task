using ProductsModels;
using System.Collections.Generic;

namespace ProductsDAL
{
    public interface IProductsDB
    {
        List<Product> GetProducts(Product searchCriteria, string searchOption);
    }
}
