using Shop.Models;

namespace Shop.Interfaces
{
    interface IDeleteProductInShowcase
    {
        void DeleteProduct(Product product, int productId, int showcaseId);
    }
}
