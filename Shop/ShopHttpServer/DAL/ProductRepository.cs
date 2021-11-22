using Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.ShopHttpServer.DAL
{
    public class ProductRepository : IProductRepository
    {
        public ShopContext ShopContext { get; private set; }

        public ProductRepository(ShopContext shopContext) 
        {
            ShopContext = shopContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return ShopContext.ProductContext.ToList();
        }

        public Product GetById(int id)
        {
            return ShopContext.ProductContext.SingleOrDefault(x => x.IdInProductList == id);
        }

        public void Add(Product entity)
        {
            ShopContext.ProductContext.Add(entity);
        }

        public void DeleteById(int id)
        {
            ShopContext.ProductContext.RemoveAll(x => x.IdInProductList == id);
        }

        public int GetCount()
        {
            return ShopContext.ProductContext.Count;
        }
    }
}
