using Shop.Models;
using System;
using System.Collections.Generic;

namespace Shop.DAL
{
    public class ShowcaseRepository : IShowcaseRepository
    {
        public ShopContext ShopContext { get; private set; }

        public ShowcaseRepository(ShopContext shopContext)
        {
            ShopContext = shopContext;
        }

        public void Add(Showcase entity)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(int productId, int showcaseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Showcase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Showcase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
