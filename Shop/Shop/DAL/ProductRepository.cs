using Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(List<Product> productContext) 
        {
            Context = productContext;
        }

        public List<Product> Context { get; private set; }

        public IEnumerable<Product> GetAll()
        {
            return Context.ToList();
        }

        public Product GetById(int id)
        {
            return Context.SingleOrDefault(x => x.IdInProductList == id);
        }

        public void Add(Product entity)
        {
            Context.Add(entity);
        }

        public void DeleteById(int id)
        {
            Context.RemoveAll(x => x.IdInProductList == id);
        }

        public int GetCount()
        {
            return Context.Count;
        }
    }
}
