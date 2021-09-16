using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.Models
{
    class ShowCase 
    {
        public delegate void ShowcaseCheker();
        public event ShowcaseCheker ErrorMessage;
        public event ShowcaseCheker CountChek;
        public event ShowcaseCheker DeleteError;
        public event ShowcaseCheker VolumeError;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }
        
        List<Product> ProductsInSwocase = new List<Product>();
        

        List<ShowCase> ShowCasesList = new List<ShowCase>();

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

        public ShowCase GetShowcase(int showcaseId) => ShowCasesList.ElementAtOrDefault(showcaseId - 1);

        public void PlaceProduct(Product product, int productId, int showcaseId)
        {
            var findProduct = product.GetProduct(productId);
            
            if (product.Chek())
            {
                //ProductsInSwocase.Add(findProduct);
                ShowCasesList[showcaseId-1].ProductsInSwocase.Add(findProduct);
                findProduct.IdInShowcase = ShowCasesList[showcaseId - 1].ProductsInSwocase.Count();
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
                var product = showcase.ProductsInSwocase;
                foreach (var p in product)
                {
                    Console.WriteLine($"    Id: {p.IdInShowcase} Name: {p.Name} Volume: {p.Volume} Time to Create: {p.TimeToCreate}");

                }
            }
        }

        public ShowCase Get(int showcaseId)
        {
            var findShowcase = ShowCasesList.ElementAtOrDefault(showcaseId - 1);
            return findShowcase;
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

        internal void Remove(int indexShowcase, ShowCase showcase)
        {
            if (ShowCasesList[indexShowcase - 1].ProductsInSwocase.Count != 0 && ShowCasesList.Count >= indexShowcase)
            {
                DeleteError?.Invoke();
            }

            if (ShowCasesList.Count >= indexShowcase && ShowCasesList[indexShowcase-1].ProductsInSwocase.Count == 0)
            {
                ShowCasesList.RemoveAt(indexShowcase - 1);
                for (int i = 0; i < ShowCasesList.Count; i++)
                {
                    ShowCasesList[i].Id = i + 1;
                }
            }

            else
            {
                CountChek?.Invoke();
            }
        }
    }   
}
