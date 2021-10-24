using Shop.Interfaces;
using Shop.Services;
using Shop.ServiceHandlers;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NotifyService notifyService = new NotifyService();
            CheckService checkService = new CheckService();
            IProductService productService = new ProductService(notifyService);
            IShowcaseService showcaseService = new ShowcaseService(notifyService);
            IProductArchiveService productArchiveService = new ProductArchiveService(notifyService);

            IProductServiceHandler productServiceHandler = new ProductServiceHandler(productService, notifyService, checkService);
            IShowcaseServiceHandler ShowcaseServiceHandler = new ShowcaseServiceHandler(showcaseService, productService, notifyService, checkService);
            IProductArchiveServiceHandler productArchiveServiceHandler = new ProductArchiveServiceHandler(notifyService, productArchiveService, showcaseService, checkService);

            var shopApplication = new ShopApplication(productServiceHandler, ShowcaseServiceHandler, notifyService, productArchiveServiceHandler);
            shopApplication.Run();
        }
    }
}
