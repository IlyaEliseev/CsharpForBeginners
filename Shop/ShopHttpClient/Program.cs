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
            var productHttpController = new ProductHttpRequestController(httpclient, baseUri);
            var showcaseHttpController = new ShowcaseHttpRequestController(httpclient, baseUri);
            var productArchiveHttpController = new ProductArchiveHttpRequestController(httpclient, baseUri);
            var clientApplication = new ClientApplication(productHttpController, productArchiveHttpController, showcaseHttpController,
                                                             checkService);
            clientApplication.Run();
        }
    }
}
