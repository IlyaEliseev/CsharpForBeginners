using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.ShopHttpClient.Controllers
{
    public class ShowcaseHttpController : IShowcaseHttpController
    {
        private readonly HttpClient _httpClient;
        private readonly string _uri;

        public ShowcaseHttpController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void CreateShowcase(string nameShowcase, double volumeShowcase)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductOnShowcase(int showcaseId, int productId)
        {
            throw new NotImplementedException();
        }

        public void DeleteShowcase(int showcaseId)
        {
            throw new NotImplementedException();
        }

        public void EditeProductOnShowcase(int productId, int showcaseId, string productName, double productVolume)
        {
            throw new NotImplementedException();
        }

        public void EditeShowcase(int showcaseId, string showcaseName, double showcaseVolume)
        {
            throw new NotImplementedException();
        }

        public void GetShowcaseInformation()
        {
            throw new NotImplementedException();
        }

        public void PlaceProductOnShowcase(int productId, int showcaseId)
        {
            throw new NotImplementedException();
        }
    }
}
