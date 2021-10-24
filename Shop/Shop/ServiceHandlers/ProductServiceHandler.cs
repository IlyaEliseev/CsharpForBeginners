using System;
using Shop.Interfaces;
using Shop.Services;

namespace Shop.ServiceHandlers
{
    public class ProductServiceHandler : IProductServiceHandler
    {
        public IProductService ProductService{ get; }
        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }

        public ProductServiceHandler(IProductService productService, NotifyService notifyService, CheckService checkService)
        {
            ProductService = productService;
            NotifyService = notifyService;
            CheckService = checkService;
        }

        public void CreateProduct()
        {
            string nameProduct = CheckService.CheckName();
            double volumeProduct = CheckService.CheckVolume();
            ProductService.Create(nameProduct, volumeProduct);
            NotifyService.RaiseCreateProductIsDone();
        }

        public void EditProduct()
        {
            if (ProductService.CheckProductAvailability())
            {
                
                int productId = CheckService.CheckProductId(ProductService);
                //if (ProductService.GetProductsCount()>= productId)
                //{
                    string productName = CheckService.CheckName();
                    double productVolume = CheckService.CheckVolume();
                    ProductService.Edit(productId, productName, productVolume);
                    NotifyService.RaiseEditProductIsDone();
                //}
                //else
                //{
                   // NotifyService.RaiseSearchProductIdIsNotSuccessful();
                //}
            }
            
        }

        public void DeleteProduct()
        {
            if (ProductService.CheckProductAvailability())
            {
                int productId = CheckService.CheckProductId(ProductService);
                ProductService.Delete(productId);
                NotifyService.RaiseDeleteProductIsDone();
            }
        }
       

        public void GetProductInformation()
        {
            if (ProductService.CheckProductAvailability())
            {
                ProductService.GetInformation();
            }
        }
    }
}
