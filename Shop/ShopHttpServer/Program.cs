using Shop.ShopHttpServer.Controllers;
using Shop.ShopHttpServer.HttpResponceControllers;
using Shop.ShopHttpServer.Services;
using System.Net;

namespace Shop.ShopHttpServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:44987/");
            var notifyService = new NotifyService();
            var checkService = new CheckService();
            IProductController productController = new ProductController(notifyService, checkService);
            IShowcaseController showcaseController = new ShowcaseController(notifyService, checkService, productController);
            IProductArchiveController productArchiveController = new ProductArchiveController(notifyService, showcaseController, checkService);
            IPathController productPathController = new ProductPathController(productController);
            IPathController showcasetPathController = new ShowcasePathController(showcaseController);
            IPathController productOnShowcasePathController = new ProductOnShowcasePathController();
            IPathController productArchivePathController = new ProductArchivePathController(productArchiveController);

            var shopServerApplication = new ShopServerApplication(httpListener, productController, showcaseController, productArchiveController, productPathController, 
                                                                    showcasetPathController, productOnShowcasePathController, productArchivePathController);
            shopServerApplication.Run();
        }
    }
}
