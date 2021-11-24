using Shop.ShopHttpServer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.ShopHttpServer.DAL
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
            ShopContext.ShowcaseContext.Add(entity); 
        }

        public IEnumerable<Showcase> GetAll()
        {
            return ShopContext.ShowcaseContext.ToList();
        }

        public Showcase GetById(int id)
        {
            return ShopContext.ShowcaseContext.SingleOrDefault(x => x.Id == id);
        }

        public int GetCount()
        {
            return ShopContext.ShowcaseContext.Count;
        }

        public void DeleteById(int id)
        {
            ShopContext.ShowcaseContext.RemoveAll((x => x.Id == id));
        }
    }
}
