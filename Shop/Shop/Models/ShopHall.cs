using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Interfaces;

namespace Shop.Models
{
    public class ShopHall : IDeleteShowcase, IGetShowcase, IChekShowcase, IGetInformationShowcase, IEditShowcase, 
        ICheckProductInShowcase, IDeleteProductInShowcase
    {
        
        public event ShowcaseCheker CountCheck;
        public event ShowcaseCheker DeleteError;
        public event ShowcaseCheker ErrorMessage;
        public event ShowcaseCheker ChekProductOnShowacse;

        public List<Showcase> _showcasesList;

        public ShopHall()
        {
            _showcasesList = new List<Showcase>();
        }

        public int GetShowcaseListCount() => _showcasesList.Count();
        public void PlaceShowcase(Showcase showcase)
        {
            _showcasesList.Add(showcase);
            showcase.Id = _showcasesList.Count();
        }
        public void DeleteShowcase(int showcaseId)
        {
            var findShowcase = GetShowcase(showcaseId);

            if (findShowcase.ProductsInShowcase.Count != 0 && _showcasesList.Count >= showcaseId)
            {
                DeleteError?.Invoke();
            }

            if (_showcasesList.Count >= showcaseId && findShowcase.ProductsInShowcase.Count == 0)
            {

                _showcasesList.RemoveAt(showcaseId - 1);
                for (int i = 0; i < _showcasesList.Count; i++)
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
                Console.WriteLine($"Id: {showcase.Id} Name: {showcase.Name} Volume: {showcase.Volume} Time to Create: {showcase.TimeToCreate} Count Products: {showcase.ProductsInShowcase.Count()}");
                var products = showcase.ProductsInShowcase;
                foreach (var p in products)
                {
                    Console.WriteLine($"    Id: {p.IdInShowcase} Name: {p.Name} Volume: {p.Volume} Time to Create: {p.TimeToCreate}");
                }
            }
        }

        public void Edit(int showcaseId, string showcaseName, double showcaseVolume)
        {
            var findShowcase = GetShowcase(showcaseId);

            if (findShowcase.GetProductCount() != 0)
            {
                DeleteError?.Invoke();
            }
            else
            {
                findShowcase.Name = showcaseName;
                findShowcase.Volume = showcaseVolume;
            }
        }

        public bool CheckProductOnShowcase(int showcaseId)
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

        public void DeleteProduct(Product product, int productId, int showcaseId)
        {
            var selectShowcase = GetShowcase(showcaseId);
            var selectProduct = selectShowcase.GetProduct(productId);

            if (GetShowcaseListCount() < showcaseId)
            {
                CountCheck?.Invoke();
                return;
            }

            if (CheckProductOnShowcase(showcaseId))
            {
                selectShowcase.ProductsInShowcase.RemoveAll(X => X.IdInShowcase == productId);

                for (int i = 0; i < selectShowcase.GetProductCount(); i++)
                {
                    selectShowcase.ProductsInShowcase[i].IdInShowcase = i + 1;
                }
            }
        }
    }
}
