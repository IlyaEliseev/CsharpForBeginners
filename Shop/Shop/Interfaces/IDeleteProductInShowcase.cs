using Shop.Models;

namespace Shop.Interfaces
{
    public interface IDeleteProductInShowcase
    {
        void DeleteProduct(Product product, int productId, int showcaseId);
    }
}
