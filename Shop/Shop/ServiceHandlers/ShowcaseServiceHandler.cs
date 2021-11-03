using Shop.Interfaces;
using Shop.Services;

namespace Shop.ServiceHandlers
{
    public class ShowcaseServiceHandler : IShowcaseServiceHandler
    {
        public IShowcaseService ShowcaseService { get; }
        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }
        public IProductController ProductController { get; set; }
        public ShowcaseServiceHandler(IShowcaseService showcaseService, NotifyService notifyService, CheckService checkService, IProductController productController)
        {
            ShowcaseService = showcaseService;
            NotifyService = notifyService;
            CheckService = checkService;
            ProductController = productController;
        }

        public void CreateShowcase(string nameShowcase, double volumeShowcase)
        {
            var createShowcase = ShowcaseService.Create(nameShowcase, volumeShowcase);
            ShowcaseService.PlaceShowcase(createShowcase);
            NotifyService.RaiseCreateShowcaseIsDone();
        }

        public void DeleteProductOnShowcase(int showcaseId, int productId)
        {
            if (ShowcaseService.CheckShowcaseAvailability() && ShowcaseService.GetShowcaseListCount() >= showcaseId)
            {
                if (ShowcaseService.CheckProductOnCurrentShowcase(showcaseId))
                {
                    
                    ShowcaseService.DeleteProduct(productId, showcaseId);
                    NotifyService.RaiseDeleteProductIsDone();
                }
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }
        
        public void DeleteShowcase(int showcaseId)
        {
            if (ShowcaseService.CheckShowcaseAvailability() && ShowcaseService.GetShowcaseListCount() >= showcaseId)
            {
                if (ShowcaseService.CheckShowcaseCount(showcaseId))
                {
                    ShowcaseService.DeleteShowcase(showcaseId);
                    NotifyService.RaiseDeleteShowcaseIsDone();
                }
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }

        public void EditeProductOnShowcase(int productId, int showcaseId, string productName,double productVolume)
        {
            if (ShowcaseService.CheckShowcaseAvailability() && ShowcaseService.GetShowcaseListCount()>= showcaseId)
            {
                if (ShowcaseService.CheckProductOnCurrentShowcase(showcaseId))
                {
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
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }

        public void EditeShowcase(int showcaseId, string showcaseName, double showcaseVolume)
        {
            if (ShowcaseService.CheckShowcaseAvailability() && ShowcaseService.GetShowcaseListCount()>= showcaseId)
            {
                ShowcaseService.EditShowcase(showcaseId, showcaseName, showcaseVolume);
                NotifyService.RaiseEditShowcaseIsDone();
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }

        public void GetShowcaseInformation()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                ShowcaseService.GetInformation();
            }
        }

        public void PlaceProductOnShowcase(int productId, int showcaseId, IProductController productController)
        {
            if (ShowcaseService.GetShowcaseListCount() >= showcaseId && productController.GetProductCount()>= productId)
            {
                if (productController.CheckProductAvailability() && ShowcaseService.CheckShowcaseAvailability())
                {
                    if (ShowcaseService.CheckShowcaseVolumeOverflow(showcaseId, productId, productController))
                    {
                        ShowcaseService.PlaceProduct(productController, productId, showcaseId);
                        NotifyService.RaisePlaceProductIsDone();
                    }
                }
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }
    }
}
