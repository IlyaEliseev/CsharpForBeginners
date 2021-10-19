using Shop.Interfaces;
using Shop.Models;

namespace Shop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NotifyService notifyService = new NotifyService();
            IProductService productService = new ProductService(notifyService);
            IShowcaseService showcaseService = new ShowcaseService(notifyService);
            IProductServiceHandler productServiceHandler = new ProductServiceHandler(productService);
            IShowcaseServiceHandler ShowcaseServiceHandler = new ShowcaseServiceHandler(showcaseService, productService, notifyService);
            var shopApplication = new ShopApplication(productServiceHandler, ShowcaseServiceHandler, notifyService);
            shopApplication.Run();
        }
    }
}
