using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.Models
{
    class ShowCase : IPlaceProduct, IGetInformation
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }
        List<ShowCase> showCasesList = new List<ShowCase>();
        List<Product> ProductsInSwocase = new List<Product>();
        public ShowCase()
        {

        }

        public ShowCase(string name, int volume)
        {
            Name = name;
            Volume = volume;
            TimeToCreate = DateTime.Now;
        }

        public void Create(string name, int volume)
        {
            ShowCase showCase = new ShowCase(name, volume);
            showCasesList.Add(showCase);
            showCase.Id = showCasesList.Count();
        }

        public void PlaceProduct(Product product)
        {
            ProductsInSwocase.Add(product);
            product.IdInProductList = ProductsInSwocase.Count();
        }

        public void GetInformation()
        {
            Console.WriteLine("Products:");

            foreach (var product in ProductsInSwocase)
            {
                Console.WriteLine($"Id: {product.IdInProductList} Name: {product.Name} Volume: {product.Volume} Time to Create: {product.TimeToCreate}");
            }
        }

        public bool Chek()
        {
            if (showCasesList.Count == 0)
            {
                ErrorMessage?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }
    }   
}
