using Shop.ShopHttpServer.Controllers;
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
            IUriPathController productUriPathController = new ProductUriPathController(productController);
            IUriPathController showcasetUrlPathController = new ShowcaseUriPathController(showcaseController);
            IUriPathController productOnShowcaseUriPathController = new ProductOnShowcaseUriPathController(showcaseController);
            IUriPathController productArchiveUriPathController = new ProductArchiveUriPathController(productArchiveController);

            var shopServerApplication = new ShopServerApplication(httpListener, productController, showcaseController, productArchiveController, productUriPathController, 
                                                                    showcasetUrlPathController, productOnShowcaseUriPathController, productArchiveUriPathController);
            shopServerApplication.Run();
        }
    }
}
