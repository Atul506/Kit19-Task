using ProductsBLL;
using ProductsModels;
using System;
using System.Web.Mvc;

namespace ProductSearch.Controllers
{
    public class ProductsController : Controller
    {
        IProductsBL _bl;

        public ProductsController(IProductsBL bl)
        {
            _bl = bl;
        }

        // GET: Products
        public ActionResult Index(string ProductName, decimal? Price, string Size, 
            string Category, DateTime? MfgDate, string searchOption)
        {
            Product searchProduct = new Product()
            {
                ProductName = ProductName,
                Price = Price,
                Size = Size,
                Category = Category,
                MfgDate = MfgDate
            };
            var products = _bl.GetProducts(searchProduct, searchOption);

            return View(products);
        }
    }
}