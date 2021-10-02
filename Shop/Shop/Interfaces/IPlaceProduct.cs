using Shop.Models;

namespace Shop.Interfaces
{
    interface IPlaceProduct
    {
        void PlaceProduct(Product product, ShopHall shop, int productId, int showcaseId);
    }
}
