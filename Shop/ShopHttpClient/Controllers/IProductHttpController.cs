
namespace Shop.ShopHttpClient.Controllers
{
    public interface IProductHttpController
    {
        void CreateProduct(string productName, double productVolume);
        void EditProduct(int productId, string productName, double productVolume);
        void DeleteProduct(int productId);
        void GetProductInformation();
    }
}