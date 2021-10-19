using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Models;

namespace Shop.Models
{
    public class Showcase 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public double VolumeCount { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }

        public List<Product> productsInShowcase = new List<Product>();
        
        public Showcase()
        {

        }

        public Showcase(string name, double volume)
        {
            Name = name;
            Volume = volume;
            TimeToCreate = DateTime.Now;
        }

        public Product GetProduct(int productId) => productsInShowcase.SingleOrDefault(x => x.IdInShowcase == productId);

        public int GetProductCount() => productsInShowcase.Count;
    }   
}
