using System.Net.Http;
using Shop.ShopHttpClient.Services;
using Shop.ShopHttpClient.Controllers;
using System;

namespace Shop.ShopHttpClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var httpclient = new HttpClient();
            var baseUri = new Uri("http://localhost:44987");
            var checkService = new CheckService();
            var notifyService = new NotifyService();
            var productHttpController = new ProductHttpController(httpclient, baseUri);
            var showcaseHttpController = new ShowcaseHttpController(httpclient, baseUri);
            var productArchiveHttpController = new ProductArchiveHttpController(httpclient, baseUri);
            var clientApplication = new ClientApplication(productHttpController, productArchiveHttpController, showcaseHttpController,
                                                            notifyService, checkService);
            clientApplication.Run();
        }
    }
}
