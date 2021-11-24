using Shop.ShopHttpServer.Models;

namespace Shop.ShopHttpServer.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopContext _context = new ShopContext();
        private IProductRepository _productRepository;
        private IShowcaseRepository _showcaseRepository;
        private IProductOnShowcaseRepository _productOnShowcaseRepository;
        private IArchiveRepository _archiveRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository==null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public IShowcaseRepository ShowcaseRepository
        {
            get
            {
                if (_showcaseRepository == null)
                {
                    _showcaseRepository = new ShowcaseRepository(_context);
                }
                return _showcaseRepository;
            }
        }

        public IProductOnShowcaseRepository ProductOnShowcaseRepository
        {
            get
            {
                if (_productOnShowcaseRepository == null)
                {
                    _productOnShowcaseRepository = new ProductOnShowcaseRepository(_context);
                }
                return _productOnShowcaseRepository;
            }
        }
        public IArchiveRepository ArchiveRepository
        {
            get
            {
                if (_archiveRepository == null)
                {
                    _archiveRepository = new ArchiveRepository(_context); ;
                }
                return _archiveRepository;
            }
        }
    }
}
