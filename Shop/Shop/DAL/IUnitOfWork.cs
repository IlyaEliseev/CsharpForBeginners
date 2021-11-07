using Shop.Models;

namespace Shop.DAL
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        IShowcaseRepository ShowcaseRepository { get; set; }
        IShowcaseRepository ProductOnShowcaseRepository { get; set; }
        IShowcaseRepository ArchiveRepository { get; set; }
    }
}
