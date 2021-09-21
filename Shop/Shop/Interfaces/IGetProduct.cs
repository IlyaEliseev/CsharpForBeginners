using Shop.Models;

namespace Shop.Interfaces
{
    interface IGetProduct
    {
        Product GetProduct(int productId);
    }
}
