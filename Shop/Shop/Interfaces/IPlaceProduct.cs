using Shop.Models;

namespace Shop.Interfaces
{
    interface IPlaceProduct
    {
        void PlaceProduct(Product product, int productId, int showcaseId);
    }
}
