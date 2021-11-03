using System.Collections.Generic;

namespace Shop.Models
{
    public class ProductContext 
    {
        public List<Product> _productStorage;

        public ProductContext()
        {
            _productStorage = new List<Product>();
        }
    }
}
