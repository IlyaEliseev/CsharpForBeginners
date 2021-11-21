using System;
using System.Net.Http;
using Shop.ShopHttpClient.Services;
using Shop.ShopHttpClient.Controllers;


namespace Shop.ShopHttpClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var httpclient = new HttpClient();
            var checkService = new CheckService();
            var notifyService = new NotifyService();
            var productHttpController = new ProductHttpController(httpclient);
            var showcaseHttpController = new ShowcaseHttpController(httpclient);
            var productArchiveHttpController = new ProductArchiveHttpController(httpclient);
            var clientApplication = new ClientApplication(productHttpController, productArchiveHttpController, showcaseHttpController,
                                                            notifyService, checkService);
            clientApplication.Run();

        }
    }
}
