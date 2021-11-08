using Shop.Models;

namespace Shop.DAL
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        IShowcaseRepository ShowcaseRepository { get; set; }
        IProductOnShowcaseRepository ProductOnShowcaseRepository { get; set; }
        IArchiveRepository ArchiveRepository { get; set; }
    }
}
