using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Models
{
    public class Product : IGetInformation, ICreateProduct, IDeleteProduct, IGetProduct, IEditProduct
    {
        public event EventHandler ProductIsNotfound;
        public event EventHandler SearchProductIdIsNotSuccessful;
        public event EventHandler CreateProductIsDone;

        public int IdInProductList { get; set; }
        public int IdInShowcase { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }

        List<Product> productList = new List<Product>();

        public Product() : base()
        {

        }

        public Product(string productName, double volume)
        {
            Name = productName;
            Volume = volume;
            TimeToCreate = DateTime.Now;
        }

        public void GetInformation()
        {
            foreach (var product in productList)
            {
                Console.WriteLine($"Id: {product.IdInProductList} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
            }
        }

        public void Create(string productName, double productVolume)
        {
            Product product = new Product(productName, productVolume);
            productList.Add(product);
            product.IdInProductList = GetProductsCount();
            CreateProductIsDone?.Invoke();
        }

        public void Delete(int productId)
        {
            if (GetProductsCount() >= productId)
            {
                productList.RemoveAll(x => x.IdInProductList == productId);
            }
            else
            {
                SearchProductIdIsNotSuccessful?.Invoke();
            }
        }

        public bool CheckProductAvailability()
        {
            if (GetProductsCount() == 0)
            {
                ProductIsNotfound?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }

        public Product GetProduct(int productId) => productList.SingleOrDefault(x => x.IdInProductList == productId);
            
        public int GetProductsCount() => productList.Count;
        public void Edit(int productId, string newProductName, double newProductVolume)
        {
            var selectProduct = GetProduct(productId);
            selectProduct.Name = newProductName;
            selectProduct.Volume = newProductVolume;
        }

        public Product Copy()
        {
            return (Product) this.MemberwiseClone();
        }

    }
}
