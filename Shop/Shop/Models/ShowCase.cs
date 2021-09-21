using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Interfaces;

namespace Shop.Models
{
    class Showcase : ICreateShowcase, IGetShowcase, IGetInformationShowcase, IPlaceProduct, 
        IChekShowcase, ICheckProductInShowcase, IDeleteProductInShowcase, IEditShowcase
    {
        public delegate void ShowcaseCheker();
        public event ShowcaseCheker ErrorMessage;
        public event ShowcaseCheker CountCheck;
        public event ShowcaseCheker DeleteError;
        public event ShowcaseCheker VolumeError;
        public event ShowcaseCheker ChekProductOnShowacse;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }
        
        List<Product> ProductsInSwocase = new List<Product>();
        List<Showcase> ShowcasesList = new List<Showcase>();
        
        public Showcase()
        {

        }

        public Showcase(string name, double volume)
        {
            Name = name;
            Volume = volume;
            TimeToCreate = DateTime.Now;
        }

        public void Create(string showcaseName, double showcaseVolume)
        {
            Showcase showcase = new Showcase(showcaseName, showcaseVolume);
            ShowcasesList.Add(showcase);
            showcase.Id = ShowcasesList.Count();
        }

        public Showcase Get(int showcaseId) => ShowcasesList[showcaseId - 1];

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
                CountCheck?.Invoke();
            }
        }
        public void GetInformation()
        {
            Console.WriteLine("Showcases:");

            foreach (var showcase in ShowcasesList)
            {
                Console.WriteLine($"Id: {showcase.Id} Name: {showcase.Name} Volume: {showcase.Volume} Time to Create: {showcase.TimeToCreate} Count Products: {showcase.ProductsInSwocase.Count()}");
                var product = showcase.ProductsInSwocase;
                foreach (var p in product)
                {
                    Console.WriteLine($"    Id: {p.IdInShowcase} Name: {p.Name} Volume: {p.Volume} Time to Create: {p.TimeToCreate}");
                }
            }
        }

        public bool Check()
        {
            if (ShowcasesList.Count == 0)
            {
                ErrorMessage?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public bool CheckProduct()
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

        public void DeleteProduct(Product product, int productId, int showcaseId)
        {
            if (Check() && CheckProduct() && ShowcasesList.Count > showcaseId) 
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
                CountCheck?.Invoke();
            }
        }

        internal void Delete(int showcaseId)
        {
            var findShowcase = Get(showcaseId);

            if (findShowcase.ProductsInSwocase.Count != 0 && ShowcasesList.Count >= showcaseId)
            {
                DeleteError?.Invoke();
            }

            if (ShowcasesList.Count >= showcaseId && findShowcase.ProductsInSwocase.Count == 0)
            {
                ShowcasesList.RemoveAt(showcaseId - 1);
                for (int i = 0; i < ShowcasesList.Count; i++)
                {
                    findShowcase.Id = i + 1;
                }
            }
            else
            {
                CountCheck?.Invoke();
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
