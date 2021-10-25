using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Services
{
    public class ProductService : IProductService
    {
        public NotifyService NotifyService { get; }

        private List<Product> _productStorage;

        public ProductService(NotifyService notifyService)
        {
            _productStorage = new List<Product>();
            NotifyService = notifyService;
        }

        public void GetInformation()
        {
            Console.WriteLine("Product storage:");

            foreach (var product in _productStorage)
            {
                Console.WriteLine($"Id: {product.IdInProductList} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
            }
        }

        public void Create(string productName, double productVolume)
        {
            Product product = new Product(productName, productVolume);
            _productStorage.Add(product);
            product.IdInProductList = GetProductsCount();
        }

        public void Delete(int productId)
        {
            if (GetProductsCount() >= productId)
            {
                _productStorage.RemoveAll(x => x.IdInProductList == productId);
                for (int i = 0; i < GetProductsCount(); i++)
                {
                    _productStorage[i].IdInProductList = i + 1;
                }
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }

        public bool CheckProductAvailability()
        {
            if (GetProductsCount() == 0)
            {
                NotifyService.RaiseProductIsNotfound();
                return false;
            }
            else
            {
                return true;
            }
        }

        public Product GetProduct(int productId) => _productStorage.SingleOrDefault(x => x.IdInProductList == productId);

        public int GetProductsCount() => _productStorage.Count;

        public void Edit(int productId, string newProductName, double newProductVolume)
        {
            var selectProduct = GetProduct(productId);
            selectProduct.Name = newProductName;
            selectProduct.Volume = newProductVolume;
        }
    }
}
