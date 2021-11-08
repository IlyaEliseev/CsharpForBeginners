using Shop.Models;

namespace Shop.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }
        public IShowcaseRepository ShowcaseRepository { get; set; }
        public IProductOnShowcaseRepository ProductOnShowcaseRepository { get; set; }
        public IArchiveRepository ArchiveRepository { get; set; }

        public UnitOfWork(ShopContext Context)
        {
            //Context = new ShopContext();
            ProductRepository = new ProductRepository(Context);
            ShowcaseRepository = new ShowcaseRepository(Context);
            ProductOnShowcaseRepository = new ProductOnShowcaseRepository(Context);
            ArchiveRepository = new ArchiveRepository(Context);
        }
    }
}
