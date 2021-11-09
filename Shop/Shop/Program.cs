using Shop.Services;
using Shop.Controllers;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NotifyService notifyService = new NotifyService();
            CheckService checkService = new CheckService();
            
            IProductController productController = new ProductController(notifyService, checkService);
            IShowcaseController showcaseController = new ShowcaseController(notifyService, checkService, productController);
            IProductArchiveController productArchiveController = new ProductArchiveController(notifyService, showcaseController, checkService);

            var shopApplication = new ShopApplication(productController, notifyService, checkService, showcaseController, productArchiveController);
            shopApplication.Run();
        }
    }
}
