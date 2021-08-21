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
        public int ShowCaseId { get; set; }
        public string ShowCaseName { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }

        List<Product> ShowCaseList = new List<Product>();
        public ShowCase()
        {

        }

        public void PlaceProduct(Product product)
        {
            ShowCaseList.Add(product);
            product.ProductIdInProductList = ShowCaseList.Count();
        }

        public void GetInformation()
        {
            Console.WriteLine("Products:");

            foreach (var product in ShowCaseList)
            {
                Console.WriteLine($"Id: {product.ProductIdInProductList} Name: {product.ProductName} Volume: {product.Volume} Time to Create: {product.TimeToCreate}");
            }
        }
    }   
}
