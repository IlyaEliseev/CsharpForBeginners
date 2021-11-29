using System.Collections.Generic;
using System.Linq;

namespace Shop.ShopModels.Models
{
    public class ProductOnShowcaseRepository 
    {
        public ProductOnShowcaseRepository(List<Product> shopContext)
        {
            ShopContext = shopContext;
        }

        public List<Product> ShopContext { get; private set; }

        public void Add(Product entity)
        {
            ShopContext.Add(entity);
        }

        public void DeleteById(int id)
        {
            ShopContext.RemoveAll(x => x.IdInShowcase == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return ShopContext.ToList();
        }

        public Product GetById(int id)
        {
            return ShopContext.SingleOrDefault(x => x.IdInShowcase == id);
        }

        public int GetCount()
        {
            return ShopContext.Count;
        }
    }
}
