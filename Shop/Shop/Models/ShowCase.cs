using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Interfaces;

namespace Shop.Models
{
    
    public class Showcase : ICreateShowcase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public double VolumeCount { get; set; }


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
        public int GetProductCount() => ProductsInShowcase.Count;
        
    }   
}
