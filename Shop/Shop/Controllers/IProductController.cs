using Shop.Models;

namespace Shop.Controllers
{
    public interface IProductController
    {
        bool CreateProduct(string nameProduct, double volumeProduct);
        void EditProduct(int productId, string nameProduct, double volumeProduct);
        void DeleteProduct(int productId);
        void GetProductInformation();
        bool CheckProductAvailability();
        Product GetProduct(int id);
        int GetProductCount();
    }
}
