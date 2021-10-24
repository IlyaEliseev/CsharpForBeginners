using Shop.Interfaces;
using Shop.Services;

namespace Shop.ServiceHandlers
{
    public class ShowcaseServiceHandler : IShowcaseServiceHandler
    {
        public IProductService ProductService { get; }
        public IShowcaseService ShowcaseService { get; }
        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }
        public ShowcaseServiceHandler(IShowcaseService showcaseService, IProductService productService, NotifyService notifyService, CheckService checkService)
        {
            ShowcaseService = showcaseService;
            ProductService = productService;
            NotifyService = notifyService;
            CheckService = checkService;
        }

        public void CreateShowcase()
        {
            string nameShowcase = CheckService.CheckName();
            double volumeShowcase = CheckService.CheckVolume();
            var createShowcase = ShowcaseService.Create(nameShowcase, volumeShowcase);
            ShowcaseService.PlaceShowcase(createShowcase);
            NotifyService.RaiseCreateShowcaseIsDone();
        }

        public void DeleteProductOnShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckService.CheckShowcaseId(ShowcaseService);
                
                if (ShowcaseService.CheckProductOnCurrentShowcase(showcaseId))
                {
                    int productId = CheckService.CheckProductIdOnShowcase(ShowcaseService, showcaseId);
                    ShowcaseService.DeleteProduct(ProductService, productId, showcaseId);
                    NotifyService.RaiseDeleteProductIsDone();
                }
            }
        }
        
        public void DeleteShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckService.CheckShowcaseId(ShowcaseService);

                if (ShowcaseService.CheckShowcaseCount(showcaseId))
                {
                    ShowcaseService.DeleteShowcase(showcaseId);
                    NotifyService.RaiseDeleteShowcaseIsDone();
                }
            }
        }

        public void EditeProductOnShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckService.CheckShowcaseId(ShowcaseService);

                if (ShowcaseService.CheckProductOnCurrentShowcase(showcaseId))
                {
                    int productId = CheckService.CheckProductIdOnShowcase(ShowcaseService, showcaseId);
                    string productName = CheckService.CheckName();
                    double productVolume = CheckService.CheckVolume();

                    if (productVolume <= ShowcaseService.GetShowcaseFreeSpace(showcaseId))
                    {
                        ShowcaseService.EditProduct(productId, showcaseId, productName, productVolume);
                        NotifyService.RaiseEditProductIsDone();
                    }
                    else
                    {
                        NotifyService.RaiseVolumeErrorMessage();
                    }
                }
            }
        }

        public void EditeShowcase()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckService.CheckShowcaseId(ShowcaseService);
                string showcaseName = CheckService.CheckName();
                double showcaseVolume = CheckService.CheckVolume();
                ShowcaseService.EditShowcase(showcaseId, showcaseName, showcaseVolume);
                NotifyService.RaiseEditShowcaseIsDone();
            }
        }

        public void GetShowcaseInformation()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                ShowcaseService.GetInformation();
            }
        }

        public void PlaceProductOnShowcase()
        {
            if (ProductService.CheckProductAvailability() && ShowcaseService.CheckShowcaseAvailability())
            {
                int showcaseId = CheckService.CheckShowcaseId(ShowcaseService);
                int productId = CheckService.CheckProductId(ProductService);

                if (ShowcaseService.CheckShowcaseVolumeOverflow(showcaseId, productId, ProductService))
                {
                    ShowcaseService.PlaceProduct(ProductService, productId, showcaseId);
                    NotifyService.RaisePlaceProductIsDone();
                }
            }
        }
    }
}
