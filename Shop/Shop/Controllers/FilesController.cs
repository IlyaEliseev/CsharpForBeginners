using Newtonsoft.Json;
using Shop.Models;
using System.Collections.Generic;
using System.IO;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Shop.Controllers
{
    public class FilesController
    {
        public string ProductsFilePath => @"D:\projects\CsharpForBeginners\Shop\Shop\Data\Products.json";
        public string ShowcasesFilePath => @"D:\projects\CsharpForBeginners\Shop\Shop\Data\Showcases.json";
        public string ArchiveProductsFilePath => @"D:\projects\CsharpForBeginners\Shop\Shop\Data\ArchiveProducts.json";

        JsonSerializer serializer = new JsonSerializer();

        public void WriteToFile(IProductController productController, IShowcaseController showcaseController, IProductArchiveController productArchiveController)
        {
            using (StreamWriter sw = new StreamWriter(ProductsFilePath))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {

                jw.Formatting = Formatting.Indented;
                var data = productController.GetProducts();
                serializer.Serialize(jw, data);
            }

            using (StreamWriter sw = new StreamWriter(ShowcasesFilePath))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                
                jw.Formatting = Formatting.Indented;
                var data = showcaseController.GetShowcases();
                serializer.Serialize(jw, data);
            }

            using (StreamWriter sw = new StreamWriter(ArchiveProductsFilePath))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {

                jw.Formatting = Formatting.Indented;
                var data = productArchiveController.GetArchiveProducts();
                serializer.Serialize(jw, data);
            }
        }

        public void ReadFromFile(IProductController productController, IShowcaseController showcaseController, IProductArchiveController productArchiveController)
        {
            using (StreamReader sr = File.OpenText(ProductsFilePath))
            {
                string json = sr.ReadToEnd();
                List<Product> deseializeData = JsonConvert.DeserializeObject<List<Product>>(json);
                if (deseializeData != null)
                {
                    foreach (var data in deseializeData)
                    {
                        productController.AddDataFromFile(data);
                    }
                }
            }

            using (StreamReader sr = File.OpenText(ShowcasesFilePath))
            {
                string json = sr.ReadToEnd();
                List<Showcase> deseializeData = JsonConvert.DeserializeObject<List<Showcase>>(json);

                if (deseializeData != null)
                {
                    foreach (var data in deseializeData)
                    {
                        showcaseController.AddDataFromFile(data);
                    }
                    
                }
            }

            using (StreamReader sr = File.OpenText(ArchiveProductsFilePath))
            {
                string json = sr.ReadToEnd();
                List<Product> deseializeData = JsonConvert.DeserializeObject<List<Product>>(json);

                if (deseializeData != null)
                {
                    foreach (var data in deseializeData)
                    {
                        productArchiveController.AddDataFromFile(data);
                    }
                }
            }

        }
    }
}
