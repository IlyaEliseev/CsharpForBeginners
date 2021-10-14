using Shop.Models;

namespace Shop.Interfaces
{
    public interface IGetProduct
    {
        Product GetProduct(int productId);
    }
}
