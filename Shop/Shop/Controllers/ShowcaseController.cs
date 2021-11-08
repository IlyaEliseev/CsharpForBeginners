using Shop.DAL;
using Shop.Interfaces;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controllers 
{
    public class ShowcaseController : IShowcaseController
    {
        public IUnitOfWork UnitOfWork { get; }
        public IProductController ProductController { get; }
        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }

        public ShowcaseController(NotifyService notifyService, CheckService checkService, IProductController productController)
        {
            NotifyService = notifyService;
            CheckService = checkService;
            ProductController = productController;
            UnitOfWork = new UnitOfWork(new ShopContext());
        }

        public void CreateShowcase(string nameShowcase, double volumeShowcase)
        {
            Showcase showcase = new Showcase(nameShowcase, volumeShowcase);
            UnitOfWork.ShowcaseRepository.Add(showcase);
            showcase.Id = UnitOfWork.ShowcaseRepository.GetCount();
            NotifyService.RaiseCreateShowcaseIsDone();
        }

        public void DeleteShowcase(int showcaseId)
        {
            if (CheckShowcaseAvailability() && ProductController.GetProductCount() >= showcaseId)
            {
                if (CheckShowcaseCount(showcaseId))
                {
                    UnitOfWork.ShowcaseRepository.DeleteById(showcaseId);
                    NotifyService.RaiseDeleteShowcaseIsDone();
                    var showcase = from s in UnitOfWork.ShowcaseRepository.GetAll()
                                   select s;
                    for (int i = 0; i < GetShowcaseCount(); i++)
                    {
                        showcase.ElementAtOrDefault(i).Id = i + 1;
                    }
                }
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }

        public void PlaceProductOnShowcase(int productId, int showcaseId)
        {
            if (GetShowcaseCount() >= showcaseId && ProductController.GetProductCount() >= productId)
            {
                if (ProductController.CheckProductAvailability() && CheckShowcaseAvailability())
                {
                    if (CheckShowcaseVolumeOverflow(showcaseId, productId, productController))
                    {
                        var selectProduct = ProductController.GetProduct(productId);
                        var selectShowcase = UnitOfWork.ShowcaseRepository.GetById(showcaseId);
                        selectShowcase.UnitOfWork.ProductOnShowcaseRepository.Add(selectProduct);
                        SumShowcaseVolume(showcaseId, productId);
                        ProductController.DeleteProduct(productId);
                        selectProduct.IdInShowcase = selectShowcase.GetProductCount();
                        selectProduct.IdShowcase = showcaseId;
                        NotifyService.RaisePlaceProductIsDone();
                    }
                }
            }
            else
            {
                NotifyService.RaiseSearchProductIdIsNotSuccessful();
            }
        }

        public void DeleteProductOnShowcase(int showcaseId, int productId)
        {
            throw new NotImplementedException();
        }

        public void EditeShowcase(int showcaseId, string showcaseName, double showcaseVolume)
        {
            throw new NotImplementedException();
        }

        public void EditeProductOnShowcase(int productId, int showcaseId, string productName, double productVolume)
        {
            throw new NotImplementedException();
        }

        public void GetShowcaseInformation()
        {
            throw new NotImplementedException();
        }

        public bool CheckShowcaseAvailability()
        {
            if (GetShowcaseCount() == 0)
            {
                NotifyService.RaiseCountCheck();
                return false;
            }
            else
            {
                return true;
            }
        }

        public double GetShowcaseFreeSpace(int showcaseId)
        {
            var selectShowcase = GetShowcase(showcaseId);
            double freespace = selectShowcase.Volume - selectShowcase.VolumeCount;
            return freespace;
        }

        public int GetShowcaseCount()
        {
            return UnitOfWork.ShowcaseRepository.GetCount();
        }

        public void SumShowcaseVolume(int showcaseId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
