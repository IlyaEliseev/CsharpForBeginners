using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.ShopHttpClient.Controllers
{
    public class ProductArchiveHttpController : IProductArchiveHttpController
    {
        private readonly HttpClient _httpClient;
        private readonly string _uri;

        public ProductArchiveHttpController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void ArchivateProduct(int productId, int showcaseId)
        {
            throw new NotImplementedException();
        }

        public void DeleteArchiveProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void GetArchiveInformation()
        {
            throw new NotImplementedException();
        }

        public void UnArchivateProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
