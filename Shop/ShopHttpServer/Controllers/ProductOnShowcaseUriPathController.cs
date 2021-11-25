using System.Collections.Generic;

namespace Shop.ShopHttpServer.Controllers
{
    public class ProductOnShowcaseUriPathController : IUriPathController
    {
        public ProductOnShowcaseUriPathController(IShowcaseController showcaseController)
        {
            ShowcaseController = showcaseController;
            _path = new List<string>();
        }

        private List<string> _path;
        public IShowcaseController ShowcaseController { get; set; }
        public string Path => "/app/showcase/product";

        public void AddUri(string uri)
        {
            if (!_path.Contains(uri))
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
