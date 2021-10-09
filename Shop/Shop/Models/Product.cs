﻿using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Models
{
    public class Product : IGetInformation, ICreateProduct, IDeleteProduct, IGetProduct, IEditProduct
    {
        public event EventHandler ProductIsNotfound;
        public event EventHandler SearchProductIdIsNotSuccessful;

        public int IdInProductList { get; set; }
        public int IdInShowcase { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public DateTime TimeToCreate { get; set; }
        public DateTime TimeToDelite { get; set; }

        List<Product> _productList = new List<Product>();

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
            foreach (var product in _productList)
            {
                Console.WriteLine($"Id: {product.IdInProductList} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
            }
        }

        public void Create(string productName, double productVolume)
        {
            Product product = new Product(productName, productVolume);
            _productList.Add(product);
            product.IdInProductList = GetProductsCount();
        }

        public void Delete(int productId)
        {
            if (GetProductsCount() >= productId)
            {
                _productList.RemoveAll(x => x.IdInProductList == productId);
                for (int i = 0; i < GetProductsCount(); i++)
                {
                    _productList[i].IdInProductList = i + 1;
                }
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

        public Product GetProduct(int productId) => _productList.SingleOrDefault(x => x.IdInProductList == productId);
            
        public int GetProductsCount() => _productList.Count;
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
