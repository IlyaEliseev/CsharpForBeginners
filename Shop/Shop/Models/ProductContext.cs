using System.Collections.Generic;

namespace Shop.Models
{
    public class ProductContext 
    {
        public List<Product> ProductStorage { get; private set; }

        public ProductContext()
        {
            ProductStorage = new List<Product>();
        }
    }
}
