using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Interfaces;

namespace Shop.Models
{
    public delegate void ShowcaseCheker();
    public class Showcase : IPlaceProduct, ICreateShowcase
        
    {
        
        public event ShowcaseCheker ErrorMessage;
        public event ShowcaseCheker CountCheck;
        public event ShowcaseCheker DeleteError;
        public event ShowcaseCheker VolumeError;
        

        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public int VolumeCount { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }

        public List<Product> ProductsInShowcase = new List<Product>();
        
        public Showcase()
        {

        }

        public Showcase(string name, double volume)
        {
            Name = name;
            Volume = volume;
            TimeToCreate = DateTime.Now;
        }

        public Showcase Create(string showcaseName, double showcaseVolume)
        {
            Showcase showcase = new Showcase(showcaseName, showcaseVolume);
            return showcase;
        }

        public Product GetProduct(int productId) => ProductsInShowcase.SingleOrDefault(x => x.IdInShowcase == productId);
        public int GetProductCount() => ProductsInShowcase.Count();
        public void PlaceProduct(Product product, ShopHall shop, int productId, int showcaseId)
        {
            var findProduct = product.GetProduct(productId);
            var findShowcase = shop.GetShowcase(showcaseId);
            
            if (findShowcase.Volume < findProduct.Volume)
            {
                VolumeError?.Invoke();
                return;
            }

            if (product.CheckProductAvailability())
            {
                var copyProduct = findProduct.Copy();
                findShowcase.ProductsInShowcase.Add(copyProduct);
                copyProduct.IdInShowcase = findShowcase.GetProductCount();
            }
            else
            {
                CountCheck?.Invoke();
            }
        }

        
        
    }   
}
