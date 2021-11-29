﻿using System;
using Shop.Services;
using Shop.DAL;
using Shop.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shop.Controllers
{
    public class ProductController : IProductController
    {
        public ProductController()
        {
            
        }

        public ProductController(NotifyService notifyService, CheckService checkService)
        {
            NotifyService = notifyService;
            CheckService = checkService;
            UnitOfWork = new UnitOfWork();
        }

        public IUnitOfWork UnitOfWork { get; }
        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }

        public bool CreateProduct(string productName, double productVolume)
        {
            Product product = new Product(productName, productVolume);
            UnitOfWork.ProductRepository.Add(product);
            product.IdInProductList = UnitOfWork.ProductRepository.GetCount();
            NotifyService.RaiseCreateProductIsDone();
            return true;
        }
        
        public void EditProduct(int productId, string productName, double productVolume)
        {
            if (CheckProductAvailability() && UnitOfWork.ProductRepository.GetCount() >= productId)
            {
                var selectProduct = UnitOfWork.ProductRepository.GetById(productId);
                selectProduct.Name = productName;
                selectProduct.Volume = productVolume;
                NotifyService.RaiseEditProductIsDone();
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }
        
        public void DeleteProduct(int productId)
        {
            if (CheckProductAvailability())
            {
                if (UnitOfWork.ProductRepository.GetCount() >= productId)
                {
                    UnitOfWork.ProductRepository.DeleteById(productId);
                    NotifyService.RaiseDeleteProductIsDone();
                    var products = from p in UnitOfWork.ProductRepository.GetAll()
                                   select p;
                    for (int i = 0; i < UnitOfWork.ProductRepository.GetCount(); i++)
                    {
                        products.ElementAtOrDefault(i).IdInProductList = i + 1;
                    }
                }
                else
                {
                    NotifyService.RaiseSearchProductIdIsNotSuccessful();
                }
            }
        }

        public void GetProductInformation()
        {
            if (CheckProductAvailability())
            {
                Console.WriteLine("Product storage:");
                foreach (var product in UnitOfWork.ProductRepository.GetAll())
                {
                    Console.WriteLine($"Id: {product.IdInProductList} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
                }
            }
        }

        public bool CheckProductAvailability()
        {
            if (UnitOfWork.ProductRepository.GetCount() == 0)
            {
                NotifyService.RaiseProductIsNotfound();
                return false;
            }
            else
            {
                return true;
            }
        }

        public Product GetProduct(int id)
        {
            return UnitOfWork.ProductRepository.GetById(id);
        }

        public int GetProductCount()
        {
            return UnitOfWork.ProductRepository.GetCount();
        }

        public IEnumerable<Product> GetProducts()
        {
            return UnitOfWork.ProductRepository.GetAll();
        }

        public void AddDataFromFile(Product product)
        {
            UnitOfWork.ProductRepository.Add(product);
        }
    }
}
