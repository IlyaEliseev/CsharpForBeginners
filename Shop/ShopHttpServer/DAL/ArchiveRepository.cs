using Shop.ShopHttpServer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.ShopHttpServer.DAL
{
    public class ArchiveRepository : IArchiveRepository
    {
        public ArchiveRepository(ShopContext shopContext)
        {
            ShopContext = shopContext;
        }

        public ShopContext ShopContext { get; private set; }

        public IEnumerable<Product> GetAll()
        {
            return ShopContext.ArchiveContext.ToList();
        }

        public Product GetById(int id)
        {
            return ShopContext.ArchiveContext.SingleOrDefault(x => x.IdInArchive == id);
        }

        public void Add(Product entity)
        {
            ShopContext.ArchiveContext.Add(entity);
        }

        public void DeleteById(int id)
        {
            ShopContext.ArchiveContext.RemoveAll(x => x.IdInArchive == id);
        }

        public int GetCount()
        {
            return ShopContext.ArchiveContext.Count;
        }
    }
}