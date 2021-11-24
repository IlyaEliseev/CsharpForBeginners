using System.Collections.Generic;
using System.Linq;

namespace Shop.ShopModels.Models
{
    public class ProductOnShowcaseRepository 
    {
        public ShopContext ShopContext { get; private set; }

        public ProductOnShowcaseRepository(ShopContext shopContext)
        {
            ShopContext = shopContext;
        }

        public void Add(Product entity)
        {
            ShopContext.ProductOnShowcaseContext.Add(entity);
        }

        public void DeleteById(int id)
        {
            ShopContext.ProductOnShowcaseContext.RemoveAll(x => x.IdInShowcase == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return ShopContext.ProductOnShowcaseContext.ToList();
        }

        public Product GetById(int id)
        {
            return ShopContext.ProductOnShowcaseContext.SingleOrDefault(x => x.IdInShowcase == id);
        }

        public int GetCount()
        {
            return ShopContext.ProductOnShowcaseContext.Count;
        }
    }
}
