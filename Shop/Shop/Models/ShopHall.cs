using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Interfaces;

namespace Shop.Models
{
    public delegate void EventHandler();  

    public class ShopHall : IDeleteShowcase, IGetShowcase, IChekShowcase, IGetInformationShowcase, IEditShowcase, 
        ICheckProductInShowcase, IDeleteProductInShowcase, IPlaceProduct
    {
        public event EventHandler CountCheck;
        public event EventHandler DeleteError;
        public event EventHandler ChekProductOnShowacse;
        public event EventHandler VolumeError;
        public event EventHandler SearchShowcaseIdIsNotSuccessful;

        public List<Showcase> _showcasesList;

        public ShopHall()
        {
            _showcasesList = new List<Showcase>();
        }

        public int GetShowcaseListCount() => _showcasesList.Count;
        public void PlaceShowcase(Showcase showcase)
        {
            _showcasesList.Add(showcase);
            showcase.Id = GetShowcaseListCount();
        }
        public void DeleteShowcase(int showcaseId)
        {
            var findShowcase = GetShowcase(showcaseId);

            if (findShowcase.GetProductCount() != 0 && GetShowcaseListCount() >= showcaseId)
            {
                DeleteError?.Invoke();
            }

            if (GetShowcaseListCount() >= showcaseId && findShowcase.GetProductCount() == 0)
            {

                _showcasesList.RemoveAll(x => x.Id == showcaseId);
                for (int i = 0; i < GetShowcaseListCount(); i++)
                {
                    _showcasesList[i].Id = i + 1;
                }
            }
            else
            {
                CountCheck?.Invoke();
            }
        }
        public Showcase GetShowcase(int showcaseId) => _showcasesList.SingleOrDefault(x => x.Id == showcaseId);

        public bool CheckShowcaseCount(int showcaseId)
        {
            var findShowcase = GetShowcase(showcaseId);
            if (findShowcase.GetProductCount() != 0)
            {
                DeleteError?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void GetInformation()
        {
            Console.WriteLine("Showcases:");

            foreach (var showcase in _showcasesList)
            {
                Console.WriteLine($"Id: {showcase.Id} | Name: {showcase.Name} | Volume: {showcase.Volume} | Time to Create: {showcase.TimeToCreate} | Count Products: {showcase.ProductsInShowcase.Count()} | VolumeCount: {showcase.VolumeCount}");
                var products = showcase.ProductsInShowcase;
                foreach (var p in products)
                {
                    Console.WriteLine($"    Id: {p.IdInShowcase} | Name: {p.Name} | Volume: {p.Volume} | Time to Create: {p.TimeToCreate}");
                }
            }
        }

        public void EditShowcase(int showcaseId, string showcaseName, double showcaseVolume)
        {
            var SelectShowcase = GetShowcase(showcaseId);

            if (SelectShowcase.GetProductCount() != 0)
            {
                DeleteError?.Invoke();
            }
            else
            {
                SelectShowcase.Name = showcaseName;
                SelectShowcase.Volume = showcaseVolume;
            }
        }

        public bool CheckProductOnCurrentShowcase(int showcaseId)
        {
            var findShowcase = GetShowcase(showcaseId);
            if (findShowcase.GetProductCount() == 0)
            {
                ChekProductOnShowacse?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckShowcaseVolumeOverflow(int showcaseId, int productId, Product product)
        {
            var _selectShowcase = GetShowcase(showcaseId);
            var _selectProduct = product.GetProduct(productId);
            if (_selectShowcase.VolumeCount <= _selectShowcase.Volume && GetShowcaseFreeVolume(showcaseId) >= _selectProduct.Volume)
            {
                return true;
            }
            VolumeError?.Invoke();
            return false;
        }

        public double GetShowcaseFreeVolume(int showcaseId)
        {
            var _selectShowcase = GetShowcase(showcaseId);
            double _freeSpace = _selectShowcase.Volume - _selectShowcase.VolumeCount;
            return _freeSpace;
        }

        public void CountShowcaseVolume(int showcaseId, int productId)
        {
            var _selectShowcase = GetShowcase(showcaseId);
            var _selectProduct = _selectShowcase.GetProduct(productId);
            _selectShowcase.VolumeCount += _selectProduct.Volume;
        }

        public void PlaceProduct(Product product,int productId, int showcaseId)
        {
            var selectProduct = product.GetProduct(productId);
            var selectShowcase = GetShowcase(showcaseId);

            if (product.CheckProductAvailability())
            {
                selectShowcase.ProductsInShowcase.Add(selectProduct);
                product.Delete(productId);
                selectProduct.IdInShowcase = selectShowcase.GetProductCount();
                CountShowcaseVolume(showcaseId, productId);
            }
            else
            {
                SearchShowcaseIdIsNotSuccessful?.Invoke();
            }
        }

        public void DeleteProduct(Product product, int productId, int showcaseId)
        {
            var selectShowcase = GetShowcase(showcaseId);
            var selectProduct = selectShowcase.GetProduct(productId);

            if (GetShowcaseListCount() < showcaseId)
            {
                CountCheck?.Invoke();
                return;
            }

            if (CheckProductOnCurrentShowcase(showcaseId))
            {
                selectShowcase.ProductsInShowcase.RemoveAll(X => X.IdInShowcase == productId);
                selectShowcase.VolumeCount-= selectProduct.Volume;
                for (int i = 0; i < selectShowcase.GetProductCount(); i++)
                {
                    selectShowcase.ProductsInShowcase[i].IdInShowcase = i + 1;
                }
            }
        }
        public void EditProduct(int productId,int showcaseId, string newProductName, double newProductVolume)
        {
            var _selectShowcase = GetShowcase(showcaseId);
            var _selectProduct = _selectShowcase.GetProduct(productId);
            _selectProduct.Name = newProductName;
            _selectProduct.Volume = newProductVolume;
        }

        public bool CheckShowcaseAvailability()
        {
            if (GetShowcaseListCount() == 0)
            {
                CountCheck?.Invoke();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
