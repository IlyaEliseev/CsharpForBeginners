using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.Models
{
    public class Product : IGetInformation, ICreateAction
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }
        List<Product> productList = new List<Product>;   
        //ICreateAction<string, double, Product> createProduct;
        public Product() : base ()
        {

        }

        public Product(string productName, double volume)
        {
            ProductName = productName;
            Volume = volume;
            TimeToCreate = DateTime.Now;            
        }

        public void GetInformation()
        {
            Console.WriteLine($"Name product: {ProductName} Volume product: {Volume} Time to create: {TimeToCreate}");
        }

        public void Create(string productName, double volume)
        {
            Product product = new Product(productName, volume);
            productList.Add(product);
        }
    }
}
