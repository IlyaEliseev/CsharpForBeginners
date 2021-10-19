using System.Collections.Generic;
using System.Linq;

namespace Shop.Models
{
    public class ProductOnShowcase
    {
        private List<Product> _productsInShowcase;

        public ProductOnShowcase()
        {
            _productsInShowcase = new List<Product>();
        }
        public List<Product> GetProductsOnShowcase()
        {
            return _productsInShowcase;
        }
        public Product GetProduct(int productId) => _productsInShowcase.SingleOrDefault(x => x.IdInShowcase == productId);

        public int GetProductCount() => _productsInShowcase.Count;
    }
}
