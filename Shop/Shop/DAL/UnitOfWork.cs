using Shop.Models;

namespace Shop.DAL
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
                    IProductRepository _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public IShowcaseRepository ShowcaseRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    IShowcaseRepository _showcaseRepository = new ShowcaseRepository(_context);
                }
                return _showcaseRepository;
            }
        }

        public IProductOnShowcaseRepository ProductOnShowcaseRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    IProductOnShowcaseRepository _productOnShowcaseRepository = new ProductOnShowcaseRepository(_context);
                }
                return _productOnShowcaseRepository;
            }
        }
        public IArchiveRepository ArchiveRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    IArchiveRepository _archiveRepository = new ArchiveRepository(_context); ;
                }
                return _archiveRepository;
            }
        }
    }
}
