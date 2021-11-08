using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class ProductOnShowcaseRepository : IProductOnShowcaseRepository
    {
        public ShopContext ShopContext { get; private set; }

        public ProductOnShowcaseRepository(ShopContext shopContext)
        {
            ShopContext = shopContext;
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
