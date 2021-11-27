using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Shop.ShopModels.Models;

namespace Shop.ShopHttpClient.Controllers
{
    public class ProductArchiveHttpController : IProductArchiveHttpController
    {
        public ProductArchiveHttpController(HttpClient httpClient, Uri baseUrl)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
        }

        private readonly HttpClient _httpClient;
        private readonly string _productArchiveUri = "http://localhost:44987/app/archiveProduct";

        public void ArchivateProduct(int productId, int showcaseId)
        {
            var newResponce = new HttpResponce()
            {
                ProductInShowcaseId = productId,
                ShowcaseId = showcaseId
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PostAsync(_productArchiveUri, stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void DeleteArchiveProduct(int productId)
        {
            var newResponce = new HttpResponce()
            {
                ProductInArchiveId = productId
            };
            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var sreingResponce = new StringContent(jsonResponce);
            var responce = _httpClient.DeleteAsync(_productArchiveUri + $"/{productId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void GetArchiveInformation()
        {
            var responce = _httpClient.GetAsync(_productArchiveUri).Result;
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
                ProductInArchiveId = productId,
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PatchAsync(_productArchiveUri, stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
    }
}
