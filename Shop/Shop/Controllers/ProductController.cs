using System;
using Shop.Interfaces;
using Shop.Services;
using Shop.DAL;
using Shop.Models;
using System.Linq;

namespace Shop.Controllers
{
    public class ProductController : IProductController
    {
        private IRepository<Product> _productRepository;
        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }

        public ProductController()
        {
            
        }

        public ProductController(NotifyService notifyService, CheckService checkService)
        {
            NotifyService = notifyService;
            CheckService = checkService;
            _productRepository = new ProductRepository();
        }

        public bool CreateProduct(string nameProduct, double volumeProduct)
        {
            Product product = new Product(nameProduct, volumeProduct);
            _productRepository.AddProduct(product);
            product.IdInProductList = _productRepository.GetCount();
            NotifyService.RaiseCreateProductIsDone();
            return true;
        }

        public void EditProduct(int productId, string productName, double productVolume)
        {
            if (CheckProductAvailability() && _productRepository.GetCount() >= productId)
            {
                var selectProduct = _productRepository.GetProduct(productId);
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
                if (_productRepository.GetCount() >= productId)
                {
                    _productRepository.RemoveProduct(productId);
                    NotifyService.RaiseDeleteProductIsDone();
                    var products = from p in _productRepository.GetProductList()
                                   select p;
                    for (int i = 0; i < _productRepository.GetCount(); i++)
                    {
                        products.ElementAtOrDefault(0).IdInProductList = i + 1;
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

                foreach (var product in _productRepository.GetProductList())
                {
                    Console.WriteLine($"Id: {product.IdInProductList} | Name product: {product.Name} | Volume product: {product.Volume} | Time to create: {product.TimeToCreate}");
                }
            }
        }

        public bool CheckProductAvailability()
        {
            if (_productRepository.GetCount() == 0)
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
            return _productRepository.GetProduct(id);
        }

        public int GetProductCount()
        {
            return _productRepository.GetCount();
        }
    }
}
