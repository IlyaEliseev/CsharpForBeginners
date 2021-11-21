
namespace Shop.DAL
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get;}
        IShowcaseRepository ShowcaseRepository { get; }
        IProductOnShowcaseRepository ProductOnShowcaseRepository { get; }
        IArchiveRepository ArchiveRepository { get; }
    }
}
