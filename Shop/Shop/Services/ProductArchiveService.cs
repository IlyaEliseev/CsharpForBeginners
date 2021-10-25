using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Services
{
    public class ProductArchiveService : IProductArchiveService
    {
        private List<Product> _productArchive;
        public NotifyService NotifyService { get; }

        public ProductArchiveService(NotifyService notifyService)
        {
            _productArchive = new List<Product>();
            NotifyService = notifyService;
        }

        public void ArchivateProduct(int productId, int showcaseId, IShowcaseService showcaseService)
        {
            var selectShowcase = showcaseService.GetShowcase(showcaseId);
            var selectProduct = selectShowcase.GetProduct(productId);
            _productArchive.Add(selectProduct);
            selectProduct.IdInArchive = GetArchiveProductCount();
            selectShowcase.productsInShowcase.Remove(selectProduct);
        }

        public void DeleteArchiveProduct(int productId)
        {
            _productArchive.RemoveAll(x => x.IdInArchive == productId);
            for (int i = 0; i < GetArchiveProductCount(); i++)
            {
                _productArchive[i].IdInArchive = i + 1;
            }
        }

        public void GetArchiveInformation()
        {
            Console.WriteLine("Archive:");
            foreach (var product in _productArchive)
            {
                Console.WriteLine($"Id: {product.IdInArchive} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate} | Time to archive: {product.TimeToArchive}");
            }
        }

        public int GetArchiveProductCount() => _productArchive.Count;

        public void UnArchivateProduct(int productId, IShowcaseService showcaseService)
        {
            var selectProduct = _productArchive.SingleOrDefault(x => x.IdInArchive == productId);
            var selectShowcase = showcaseService.GetShowcase(selectProduct.IdShowcase);
            selectShowcase.productsInShowcase.Add(selectProduct);
            selectProduct.IdInShowcase= selectShowcase.GetProductCount();
            _productArchive.Remove(selectProduct);
        }
    }
}
