using System;

namespace ProductsModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public decimal? Price { get; set; }
        public DateTime? MfgDate { get; set; }
        public string Category { get; set; }
    }
}
