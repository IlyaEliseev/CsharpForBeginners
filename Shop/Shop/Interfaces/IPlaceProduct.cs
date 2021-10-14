using Shop.Models;

namespace Shop.Interfaces
{
    public interface IPlaceProduct
    {
        void PlaceProduct(Product product, int productId, int showcaseId);
    }
}
