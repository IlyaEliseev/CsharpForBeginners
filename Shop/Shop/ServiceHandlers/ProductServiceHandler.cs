using System;
using Shop.Interfaces;

namespace Shop.ServiceHandlers
{
    class ProductServiceHandler : IProductServiceHandler
    {
        public IProductService ProductService{ get; }
        public NotifyService NotifyService { get; }

        public ProductServiceHandler(IProductService productService, NotifyService notifyService)
        {
            ProductService = productService;
            NotifyService = notifyService;
        }

        public void CreateProduct()
        {
            Console.WriteLine("Input name of product: ");
            string nameProduct = Console.ReadLine();
            Console.WriteLine("Input volume of product: ");
            double volumeProduct = CheckCorrectnessVolume();
            ProductService.Create(nameProduct, volumeProduct);
            NotifyService.RaiseCreateProductIsDone();
        }

        public void EditProduct()
        {
            if (ProductService.CheckProductAvailability())
            {
                int productId = CheckCorrectnessProductId();
                Console.WriteLine("Input product name: ");
                string productName = Console.ReadLine();
                Console.WriteLine("Input product volume: ");
                double productVolume = CheckCorrectnessVolume();
                ProductService.Edit(productId, productName, productVolume);
                NotifyService.RaiseEditProductIsDone();
            }
        }

        public void DeleteProduct()
        {
            if (ProductService.CheckProductAvailability())
            {
                int productId = CheckCorrectnessProductId();
                ProductService.Delete(productId);
                NotifyService.RaiseDeleteProductIsDone();
            }
        }

        public static double CheckCorrectnessVolume()
        {
            double verifiableVolume;
            bool isContinue = true;

            do
            {
                string volume = Console.ReadLine();
                bool succses = double.TryParse(volume, out verifiableVolume);
                if (succses == false)
                {
                    Messages.SetRedColor("Wronge value!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableVolume;
        }
        
        public int CheckCorrectnessProductId()
        {
            int verifiableId;
            bool isContinue = true;

            do
            {
                Console.WriteLine("Input product Id: ");
                string id = Console.ReadLine();
                bool succses = int.TryParse(id, out verifiableId);
                if (succses == false || ProductService.GetProductsCount() < verifiableId)
                {
                    Messages.SetRedColor("Wrong id!");
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue);

            return verifiableId;
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
