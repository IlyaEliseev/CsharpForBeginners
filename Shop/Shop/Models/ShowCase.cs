using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;

namespace Shop.Models
{
    class ShowCase : ICreateAction, IPlaceProduct, IGetInformation
    {
        public int ShowCaseId { get; set; }
        public string ShowCaseName { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }

        List<Product> ProductList = new List<Product>();
        public ShowCase()
        {
                
        }

        public void Create()
        {
            //Console.WriteLine("Input ShowCase name: ");
            //string _showCaseName = Console.ReadLine();
            //Console.WriteLine("Input ShowCase volume: ");
            //double _showCaseVolume = double.Parse(Console.ReadLine());
        }

        public void PlaceProduct(Product product)
        {
            ProductList.Add(product);
            product.ProductId = ProductList.Count();
        }

        public void GetInformation()
        {            
            Console.WriteLine("Products:");

            foreach (var product in ProductList)
            {
                Console.WriteLine($"Id: {product.ProductId} Name: {product.ProductName} Volume: {product.Volume} Time to Create: {product.TimeToCreate}");
            }
        }

    }
}
