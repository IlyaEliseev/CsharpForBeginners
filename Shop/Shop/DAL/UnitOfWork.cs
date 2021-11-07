using Shop.Models;

namespace Shop.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        
        //public ShopContext Context { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IShowcaseRepository ShowcaseRepository { get; set; }

        public UnitOfWork(ShopContext Context)
        {
            Context = new ShopContext();
            ProductRepository = new ProductRepository(Context);
            ShowcaseRepository = new ShowcaseRepository(Context);
        }

    }
}
