using Shop.ShopHttpServer.Models;
using System.Collections.Generic;

namespace Shop.ShopHttpServer.Controllers
{
    public interface IProductController
    {
        void CreateProduct(string nameProduct, double volumeProduct);
        void EditProduct(int productId, string nameProduct, double volumeProduct);
        void DeleteProduct(int productId);
        //void GetProductInformation();
        bool CheckProductAvailability();
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        int GetProductCount();
    }
}
