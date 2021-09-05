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
        public delegate void ShowcaseCheker();
        public event ShowcaseCheker ErrorMessage;
        public event ShowcaseCheker CountChek;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }
        List<ShowCase> ShowCasesList = new List<ShowCase>();
        List<Product> ProductsInSwocase = new List<Product>();
        public ShowCase()
        {

        }

        public ShowCase(string name, double volume)
        {
            Name = name;
            Volume = volume;
            TimeToCreate = DateTime.Now;
        }

        public void Create(string name, double volume)
        {
            ShowCase showCase = new ShowCase(name, volume);
            ShowCasesList.Add(showCase);
            showCase.Id = ShowCasesList.Count();
        }

        public void PlaceProduct(Product product, int productId)
        {
            if (product.Chek() && product.IdInProductList == productId)
            {
                ProductsInSwocase.Add(product);
                product.IdInShowcase = ProductsInSwocase.Count();
            }
            else
            {
                CountChek?.Invoke();
            }
            
        }

        public void GetInformation()
        {
            Console.WriteLine("Showcases:");

            foreach (var showcase in ShowCasesList)
            {
                Console.WriteLine($"Id: {showcase.Id} Name: {showcase.Name} Volume: {showcase.Volume} Time to Create: {showcase.TimeToCreate}");
            }
            
        }

        public bool Chek()
        {
            if (ShowCasesList.Count == 0)
            {
                ErrorMessage?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void Remove(int indexShowcase)
        {
            if (ShowCasesList.Count >= indexShowcase)
            {
                ShowCasesList.RemoveAt(indexShowcase - 1);
            }
            else
            {
                CountChek?.Invoke();
            }
        }
    }   
}
