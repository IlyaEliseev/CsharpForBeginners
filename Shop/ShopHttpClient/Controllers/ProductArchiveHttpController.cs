using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Shop.ShopModels.Models;

namespace Shop.ShopHttpClient.Controllers
{
    public class ProductArchiveHttpController : IProductArchiveHttpController
    {
        private readonly HttpClient _httpClient;
        private readonly string _uri;

        public ProductArchiveHttpController(HttpClient httpClient, Uri baseUrl)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
        }

        public void ArchivateProduct(int productId, int showcaseId)
        {
            var newResponce = new HttpResponce()
            {
                ProductInShowcaseId = productId,
                ShowcaseId = showcaseId
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PatchAsync("http://localhost:44987/app/archiveProduct", stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }

        public void DeleteArchiveProduct(int productId)
        {
            var newResponce = new HttpResponce()
            {
                ProductInArchiveId = productId
            };
            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var sreingResponce = new StringContent(jsonResponce);
            var responce = _httpClient.DeleteAsync($"http://localhost:44987/app/archiveProduct/{productId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }

        public void GetArchiveInformation()
        {
            var responce = _httpClient.GetAsync("http://localhost:44987/app/archiveProduct").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            var archiveProducts = JsonConvert.DeserializeObject<List<Product>>(content);

            foreach (var product in archiveProducts)
            {
                Console.WriteLine($"Id: {product.IdInArchive} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToArchive}");
            }
        }

        public void UnArchivateProduct(int productId)
        {
            var newResponce = new HttpResponce()
            {
                ProductInShowcaseId = productId,
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PatchAsync("http://localhost:44987/app/archiveProduct", stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }
    }
}
