using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Shop.Models;
using Shop.ShopHttpClient.HttpModels;
using Shop.ShopHttpClient.Controllers;
using System.Collections.Generic;

namespace Shop.ShopHttpClient.Controllers
{
    public class ProductHttpController : IProductHttpController
    {
        private readonly HttpClient _httpClient;
        private readonly string _uri;

        public ProductHttpController(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            var responce = _httpClient.PostAsync("http://localhost:44987/app/product", stringContent).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }

        public void DeleteProduct(int productId)
        {
            var httpResponce = new HttpResponce()
            {
                ProductId = productId
            };

            var responce = _httpClient.DeleteAsync($"http://localhost:44987/app/product/{productId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
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
            var responce = _httpClient.PutAsync("http://localhost:44987/app/product", stringContent).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }

        public void GetProductInformation()
        {
            var responce = _httpClient.GetAsync("http://localhost:44987/app/product").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.IdInProductList} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
            }
        }
    }
}
