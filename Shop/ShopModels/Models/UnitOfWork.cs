using System.Collections.Generic;

namespace Shop.ShopModels.Models
{
    public class UnitOfWork
    {
        private ShopContext _context = new ShopContext();
        private ProductOnShowcaseRepository _productOnShowcaseRepository;
        public ProductOnShowcaseRepository ProductOnShowcaseRepository
        {
            get
            {
                if (_productOnShowcaseRepository == null)
                {
                    _productOnShowcaseRepository = new ProductOnShowcaseRepository(_context.ProductOnShowcaseContext);
                }
                return _productOnShowcaseRepository;
            }
        }
    }
}