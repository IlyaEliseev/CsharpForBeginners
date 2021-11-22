using Shop.ShopHttpServer.Controllers;
using Shop.ShopHttpServer.Services;
using System;
using System.Net;

namespace Shop.ShopHttpServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:44987/");
            NotifyService notifyService = new NotifyService();
            CheckService checkService = new CheckService();
            IProductController productController = new ProductController(notifyService, checkService);

            var shopServerApplication = new ShopServerApplication(httpListener, productController);
            shopServerApplication.Run();
        }
    }
}
