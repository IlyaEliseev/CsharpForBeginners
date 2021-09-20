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
        public event ShowcaseCheker ChekProductOnShowacse;
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

        public ShowCase Get(int showcaseId) => ShowCasesList[showcaseId - 1];

        public void PlaceProduct(Product product, int productId, int showcaseId)
        {
            var findProduct = product.GetProduct(productId);
            var findShowcase = Get(showcaseId);

            if (findShowcase.Volume < findProduct.Volume)
            {
                VolumeError?.Invoke();
                return;
            }

            if (product.Chek())
            {
                findShowcase.ProductsInSwocase.Add(findProduct);
                findProduct.IdInShowcase = findShowcase.ProductsInSwocase.Count();
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
                Console.WriteLine($"Id: {showcase.Id} Name: {showcase.Name} Volume: {showcase.Volume} Time to Create: {showcase.TimeToCreate} Count Products: {showcase.ProductsInSwocase.Count()}");
                var product = showcase.ProductsInSwocase;
                foreach (var p in product)
                {
                    Console.WriteLine($"    Id: {p.IdInShowcase} Name: {p.Name} Volume: {p.Volume} Time to Create: {p.TimeToCreate}");
                }
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
        
        public bool ChekProduct()
        {
            if (ProductsInSwocase.Count == 0)
            {
                ChekProductOnShowacse?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void DeleteProduct(Product product, int productId, int showcaseId)
        {
            if (Chek() && ChekProduct() && ShowCasesList.Count > showcaseId) 
            {
                var selectProduct = product.GetProduct(productId);
                var selectShowcase = Get(showcaseId);

                selectShowcase.ProductsInSwocase.RemoveAt(productId - 1);
                for (int i = 0; i < ProductsInSwocase.Count; i++)
                {
                    selectProduct.IdInShowcase = i + 1;
                }
            }
            else
            {
                CountChek?.Invoke();
            }
        }

        internal void Delete(int showcaseId, ShowCase showcase)
        {
            var findShowcase = Get(showcaseId);

            if (findShowcase.ProductsInSwocase.Count != 0 && ShowCasesList.Count >= showcaseId)
            {
                DeleteError?.Invoke();
            }

            if (ShowCasesList.Count >= showcaseId && findShowcase.ProductsInSwocase.Count == 0)
            {
                ShowCasesList.RemoveAt(showcaseId - 1);
                for (int i = 0; i < ShowCasesList.Count; i++)
                {
                    findShowcase.Id = i + 1;
                }
            }

            else
            {
                CountChek?.Invoke();
            }
        }

        public void Edit(int showcaseId, string showcaseName, double showcaseVolume)
        {
            var findShowcase = Get(showcaseId);

            if (findShowcase.ProductsInSwocase.Count == 0)
            {
                findShowcase.Name = showcaseName;
                findShowcase.Volume = showcaseVolume;
            }

            else
            {
                DeleteError?.Invoke();
            }
        }
    }   
}
