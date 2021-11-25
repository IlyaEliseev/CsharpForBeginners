using System.Collections.Generic;

namespace Shop.ShopHttpServer.Controllers
{
    public class ShowcaseUriPathController : IUriPathController
    {
        public ShowcaseUriPathController(IShowcaseController showcaseController)
        {
            ShowcaseController = showcaseController;
            _path = new List<string>();
        }

        public IShowcaseController ShowcaseController { get; }
        private List<string> _path;

        public string Path => "/app/showcase";

        public void AddUri(string uri)
        {
            if (!_path.Contains(uri) && _path.Count <= ShowcaseController.GetShowcaseCount())
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
