using System;
using System.Net.Http;
using Shop.ShopModels.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Shop.ShopHttpServer.Models;

namespace Shop.ShopHttpClient.Controllers
{
    public class ShowcaseHttpRequestController : IShowcaseHttpRequestController
    {
        public ShowcaseHttpRequestController(HttpClient httpClient, Uri baseUrl)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
        }

        private readonly HttpClient _httpClient;
        private readonly string _showcasPath = "app/showcase"; 
        private readonly string _productOnShowcasePath = "app/showcase/product";

        public void CreateShowcase(string nameShowcase, double volumeShowcase)
        {
            var newResponce = new Showcase()
            {
                Name = nameShowcase,
                Volume = volumeShowcase
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce, Encoding.UTF8, "application/json");
            var responce = _httpClient.PostAsync(_showcasPath, stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void DeleteProductOnShowcase(int showcaseId, int productId)
        {
            var responce = _httpClient.DeleteAsync($"app/showcase/{showcaseId}/product/{productId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void DeleteShowcase(int showcaseId)
        {
            var responce = _httpClient.DeleteAsync(_showcasPath + $"/{showcaseId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void EditeProductOnShowcase(int productId, int showcaseId, string productName, double productVolume)
        {
            var newResponce = new HttpResponceModel()
            {
                ProductInShowcaseId = productId,
                ShowcaseId = showcaseId,
                ProductName = productName,
                ProductVolume = productVolume
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PutAsync(_productOnShowcasePath, stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void EditeShowcase(int showcaseId, string showcaseName, double showcaseVolume)
        {
            var newResponce = new Showcase()
            {
                Id = showcaseId,
                Name = showcaseName,
                Volume = showcaseVolume
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PutAsync(_showcasPath, stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        public void GetShowcaseInformation()
        {
            var resopnce = _httpClient.GetAsync(_showcasPath).Result;
            var content = resopnce.Content.ReadAsStringAsync().Result;
            var showcases = JsonConvert.DeserializeObject<List<Showcase>>(content);

            foreach (var showcase in showcases)
            {
                Console.WriteLine("Showcases:");
                Console.WriteLine($"Id: {showcase.Id} | Name: {showcase.Name} | Volume: {showcase.Volume} | Time to Create: {showcase.TimeToCreate} | Count Products: {showcase.UnitOfWork.ProductOnShowcaseRepository.GetCount()}| VolumeCount: {showcase.VolumeCount}");
                foreach (var p in showcase.UnitOfWork.ProductOnShowcaseRepository.GetAll())
                {
                    Console.WriteLine($"    Id: {p.IdInShowcase} | Name: {p.Name} | Volume: {p.Volume} | Time to Create: {p.TimeToCreate}");
                }
            }
        }

        public void PlaceProductOnShowcase(int productId, int showcaseId)
        {
            var newResponce = new HttpResponceModel()
            {
                ProductId = productId,
                ShowcaseId = showcaseId
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var resopnce = _httpClient.PatchAsync(_showcasPath, stringResponce).Result;
            var content = resopnce.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
    }
}
