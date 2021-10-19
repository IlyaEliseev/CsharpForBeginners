using System;
using Shop.Models;

namespace Shop.Interfaces
{
    public interface IProductService
    {
        void Create(string productName, double volume);
        void GetInformation();
        void Delete(int productId);
        Product GetProduct(int productId);
        void Edit(int productId, string newName, double newVolume);
        bool CheckProductAvailability();
        int GetProductsCount();
    }
}
