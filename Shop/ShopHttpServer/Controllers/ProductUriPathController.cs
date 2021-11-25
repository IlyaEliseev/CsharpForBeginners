using System.Collections.Generic;

namespace Shop.ShopHttpServer.Controllers
{
    public class ProductUriPathController : IUriPathController
    {
        public ProductUriPathController(IProductController productController)
        {
            ProductController = productController;
            _path = new List<string>();
        }

        public IProductController ProductController { get; }
        private List<string> _path; 

        public string Path => "/app/product";

        public void AddUri(string uri)
        {
            if (!_path.Contains(uri) && _path.Count <= ProductController.GetProductCount())
            {
                _path.Add(uri);
            }
        }

        public string FindUri(string uri)
        {
            return _path.Find(x => x == uri);
        }
    }
}
