using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.Models
{
    public class Product : IGetInformation, ICreateProduct, IRemoveProduct
    {
        public int ProductIdInProductList { get; set; }

        public string ProductName { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }
        List<Product> productList = new List<Product>();   
        
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
            foreach (var product in productList)
            {
                Console.WriteLine($"Id: {product.ProductIdInProductList} | Name product: {product.ProductName} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
            }
        }

        public void Create(string productName, double volume)
        {
            Product product = new Product(productName, volume);
            productList.Add(product);
            product.ProductIdInProductList = productList.Count();
        }

        public void RemoveProduct(int index)
        {
            productList.RemoveAt(index - 1);
        }

        public void CheckNullProductLIstCount()
        {
            if (productList.Count == 0)
            {
                Console.WriteLine("You no create a product");
                return;
            }
        }

    }
}
