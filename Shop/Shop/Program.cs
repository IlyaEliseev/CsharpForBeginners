using Shop.Interfaces;
using Shop.Services;
using Shop.ServiceHandlers;
using Shop.Controllers;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NotifyService notifyService = new NotifyService();
            CheckService checkService = new CheckService();
            
            IShowcaseService showcaseService = new ShowcaseService(notifyService);
            IProductArchiveService productArchiveService = new ProductArchiveService(notifyService);
            IProductController productController = new ProductController(notifyService, checkService);
            IShowcaseServiceHandler ShowcaseServiceHandler = new ShowcaseServiceHandler(showcaseService, notifyService, checkService, productController);
            IProductArchiveServiceHandler productArchiveServiceHandler = new ProductArchiveServiceHandler(notifyService, productArchiveService, showcaseService, checkService);
            
            var shopApplication = new ShopApplication(productController, ShowcaseServiceHandler, notifyService, productArchiveServiceHandler, checkService);
            shopApplication.Run();
        }
    }
}
