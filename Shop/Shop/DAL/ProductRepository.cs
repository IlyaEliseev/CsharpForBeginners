using Shop.Models;
using System.Collections.Generic;
using System.Linq;
using Shop.Services;

namespace Shop.DAL
{
    public class ProductRepository : IRepository<Product>
    {
        public ProductContext ProductContext { get; private set; }

        public ProductRepository()
        {
            ProductContext = new ProductContext();
        }

        public IEnumerable<Product> GetProductList()
        {
            return ProductContext._productStorage.ToList();
        }

        public Product GetProduct(int id)
        {
            return ProductContext._productStorage.SingleOrDefault(x => x.IdInProductList == id);
        }

        public void AddProduct(Product entity)
        {
            ProductContext._productStorage.Add(entity);
        }

        public void RemoveProduct(int id)
        {
            ProductContext._productStorage.RemoveAll(x => x.IdInProductList == id);
        }

        public int GetCount()
        {
            return ProductContext._productStorage.Count;
        }
    }
}
