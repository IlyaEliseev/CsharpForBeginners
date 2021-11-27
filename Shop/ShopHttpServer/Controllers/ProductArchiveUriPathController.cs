using System.Collections.Generic;

namespace Shop.ShopHttpServer.Controllers
{
    public class ProductArchiveUriPathController : IUriPathController
    {
        public ProductArchiveUriPathController(IProductArchiveController productArchiveController)
        {
            ProductArchiveController = productArchiveController;
            _path = new List<string>();
        }

        private List<string> _path;
        public IProductArchiveController ProductArchiveController { get; set; }
        public string Path => "/app/archiveProduct";

        public void AddUri(string uri)
        {
            if (!_path.Contains(uri) && _path.Count <= ProductArchiveController.GetArchiveProductCount())
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
