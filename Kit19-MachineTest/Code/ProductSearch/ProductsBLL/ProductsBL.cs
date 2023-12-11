using ProductsDAL;
using ProductsModels;
using System.Collections.Generic;

namespace ProductsBLL
{
    public class ProductsBL : IProductsBL
    {
        IProductsDB _db;

        public ProductsBL(IProductsDB db)
        {
            _db = db;
        }

        public List<Product> GetProducts(Product searchCriteria, string searchOption)
        {
            var product = new Product()
            {
                ProductName = !string.IsNullOrEmpty(searchCriteria.ProductName) ? searchCriteria.ProductName : null,
                Size = searchCriteria.Size != "-1" ? searchCriteria.Size : null,
                Price = searchCriteria.Price,
                MfgDate = searchCriteria.MfgDate,
                Category = searchCriteria.Category != "-1" ? searchCriteria.Category : null
            };

            searchOption = searchOption != "-1" ? searchOption : null;

            return _db.GetProducts(product, searchOption);
        }
    }
}
