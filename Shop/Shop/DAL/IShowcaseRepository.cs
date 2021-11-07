using Shop.Models;

namespace Shop.DAL
{
    public interface IShowcaseRepository : IRepository<Showcase>
    {
        void AddProduct(int productId, int showcaseId);
    }
}
