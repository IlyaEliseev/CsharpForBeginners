using Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL
{
    public class ShowcaseRepository : IShowcaseRepository
    {
        public ShowcaseRepository(List<Showcase> shopContext)
        {
            Context = shopContext;
        }

        public List<Showcase> Context { get; private set; }

        public void Add(Showcase entity)
        {
            Context.Add(entity); 
        }

        public IEnumerable<Showcase> GetAll()
        {
            return Context.ToList();
        }

        public Showcase GetById(int id)
        {
            return Context.SingleOrDefault(x => x.Id == id);
        }

        public int GetCount()
        {
            return Context.Count;
        }

        public void DeleteById(int id)
        {
            Context.RemoveAll((x => x.Id == id));
        }
    }
}
