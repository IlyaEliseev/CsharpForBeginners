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
            IUriPathController productUriPathController = new ProductUriPathController(productController);
            IUriPathController showcasetUrlPathController = new ShowcaseUriPathController(showcaseController);
            IUriPathController productOnShowcaseUriPathController = new ProductOnShowcaseUriPathController(showcaseController);

            var shopServerApplication = new ShopServerApplication(httpListener, productController, showcaseController, productUriPathController, 
                                                                    showcasetUrlPathController, productOnShowcaseUriPathController);
            shopServerApplication.Run();
        }
    }
}
