using Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL
{
    public class ProductRepository : IRepository<Product>
    {
        public ProductContext Context { get; private set; }

        public ProductRepository()
        {
            Context = new ProductContext();
        }

        public IEnumerable<Product> GetProductList()
        {
            return Context.ProductStorage.ToList();
        }

        public Product GetProduct(int id)
        {
            return Context.ProductStorage.SingleOrDefault(x => x.IdInProductList == id);
        }

        public void AddProduct(Product entity)
        {
            Context.ProductStorage.Add(entity);
        }

        public void RemoveProduct(int id)
        {
            Context.ProductStorage.RemoveAll(x => x.IdInProductList == id);
        }

        public int GetCount()
        {
            return Context.ProductStorage.Count;
        }
    }
}
