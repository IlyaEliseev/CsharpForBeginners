using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.ShopHttpClient.Controllers
{
    public class ProductHttpController : IProductHttpController
    {
        private readonly HttpClient _httpClient;
        private readonly string _uri;

        public ProductHttpController(HttpClient httpClient, Uri baseUrl)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
        }

        public void CreateProduct(string productName, double productVolume)
        {
            var newProduct = new Product()
            {
                Name = productName,
                Volume = productVolume
            };

            var jsonContent = JsonConvert.SerializeObject(newProduct);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "aplication/json");
            var responce = _httpClient.PostAsync("app/product", stringContent).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void DeleteProduct(int productId)
        {
            var httpResponce = new HttpResponce()
            {
                ProductId = productId
            };

            var responce = _httpClient.DeleteAsync($"app/product/{productId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void EditProduct(int productId, string productName, double productVolume)
        {
            var newProduct = new Product()
            {
                IdInProductList = productId,
                Name = productName,
                Volume = productVolume
            };

            var jsonContent = JsonConvert.SerializeObject(newProduct);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "aplication/json");
            var responce = _httpClient.PutAsync("app/product", stringContent).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void GetProductInformation()
        {
            var responce = _httpClient.GetAsync("app/product").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.IdInProductList} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
            }
        }
    }
}
