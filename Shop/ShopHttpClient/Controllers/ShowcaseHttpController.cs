using System;
using System.Net.Http;
using Shop.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Shop.ShopHttpClient.Controllers
{
    public class ShowcaseHttpController : IShowcaseHttpController
    {
        private readonly HttpClient _httpClient;
        private readonly string _uri;

        public ShowcaseHttpController(HttpClient httpClient, Uri baseUrl)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
        }

        public void CreateShowcase(string nameShowcase, double volumeShowcase)
        {
            var newResponce = new Showcase()
            {
                Name = nameShowcase,
                Volume = volumeShowcase
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PostAsync("http://localhost:44987/app/showcase", stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            }

        public void DeleteProductOnShowcase(int showcaseId, int productId)
        {
            var newResponce = new HttpResponce()
            {
                ShowcaseId = showcaseId,
                ProductInShowcaseId = productId
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.DeleteAsync($"http://localhost:44987/app/showcase/product/{productId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }

        public void DeleteShowcase(int showcaseId)
        {
            var newResponce = new HttpResponce()
            {
                ShowcaseId = showcaseId
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.DeleteAsync($"http://localhost:44987/app/showcase/{showcaseId}").Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }

        public void EditeProductOnShowcase(int productId, int showcaseId, string productName, double productVolume)
        {
            var newResponce = new HttpResponce()
            {
                ProductInShowcaseId = productId,
                ShowcaseId = showcaseId,
                ProductName = productName,
                ProductVolume = productVolume
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var responce = _httpClient.PutAsync("http://localhost:44987/app/showcase", stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
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
            var responce = _httpClient.PutAsync("http://localhost:44987/app/showcase", stringResponce).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
        }

        public void GetShowcaseInformation()
        {
            var showcases = JsonConvert.DeserializeObject<List<Showcase>>("http://localhost:44987/app/showcase");
            foreach (var showcase in showcases)
            {
                Console.WriteLine($"Id: {showcase.Id} | Name: {showcase.Name} | Volume: {showcase.Volume} | Time to Create: {showcase.TimeToCreate} | Count Products: {showcase.GetProductCount()} | VolumeCount: {showcase.VolumeCount}");
                var products = from p in showcase.UnitOfWork.ProductOnShowcaseRepository.GetAll()
                               select p;
                foreach (var p in products)
                {
                    Console.WriteLine($"    Id: {p.IdInShowcase} | Name: {p.Name} | Volume: {p.Volume} | Time to Create: {p.TimeToCreate}");
                }
            }
        }

        public void PlaceProductOnShowcase(int productId, int showcaseId)
        {
            var newResponce = new HttpResponce()
            {
                ProductId = productId,
                ShowcaseId = showcaseId
            };

            var jsonResponce = JsonConvert.SerializeObject(newResponce);
            var stringResponce = new StringContent(jsonResponce);
            var resopnce = _httpClient.PatchAsync("http://localhost:44987/app/showcase", stringResponce).Result;
            var content = resopnce.Content.ReadAsStringAsync().Result;
        }
    }
}
