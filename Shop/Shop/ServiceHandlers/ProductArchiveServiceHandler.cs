using Shop.Interfaces;
using Shop.Services;
using System;

namespace Shop.ServiceHandlers
{
    public class ProductArchiveServiceHandler : IProductArchiveServiceHandler
    {
        public NotifyService NotifyService { get; }
        public IProductArchiveService ProductArchiveService { get; }
        public IShowcaseService ShowcaseService { get; }
        public CheckService CheckService { get; }

        public ProductArchiveServiceHandler(NotifyService notifyService, IProductArchiveService productArchiveService, IShowcaseService showcaseService, CheckService checkService)
        {
            NotifyService = notifyService;
            ProductArchiveService = productArchiveService;
            ShowcaseService = showcaseService;
            CheckService = checkService;
        }

        public void ArchivateProduct()
        {
            if (ShowcaseService.CheckShowcaseAvailability())
            {
                var showcaseId = CheckService.CheckShowcaseId(ShowcaseService);
                if (ShowcaseService.CheckProductOnCurrentShowcase(showcaseId))
                {
                    int productId = CheckService.CheckProductIdOnShowcase(ShowcaseService, showcaseId);
                    ProductArchiveService.ArchivateProduct(productId, showcaseId, ShowcaseService);
                    NotifyService.RaiseArchivateProductIsDone();
                }
            }
        }

        public void DeleteArchiveProduct()
        {
            if (CheckArchiveAvailability())
            {
                int productId = CheckService.CheckProductIdInArchive(ProductArchiveService);
                ProductArchiveService.DeleteArchiveProduct(productId);
                NotifyService.RaiseDeleteArchiveProductIsDone();
            }
        }

        public void GetArchiveInformation()
        {
            if (CheckArchiveAvailability())
            {
                ProductArchiveService.GetArchiveInformation();
            }
        }

        public void UnArchivateProduct()
        {
            if (CheckArchiveAvailability())
            {
                var productId = CheckService.CheckProductIdInArchive(ProductArchiveService);
                ProductArchiveService.UnArchivateProduct(productId, ShowcaseService);
                NotifyService.RaiseUnArchivateProductIsDone();
            }
        }
        
        public bool CheckArchiveAvailability()
        {
            if (ProductArchiveService.GetArchiveProductCount()==0)
            {
                NotifyService.RaiseArchiveIsEmpty();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
