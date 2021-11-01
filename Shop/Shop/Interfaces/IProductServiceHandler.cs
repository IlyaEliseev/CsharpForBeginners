
namespace Shop.Interfaces
{
    public interface IProductServiceHandler
    {
        bool CreateProduct();
        void EditProduct();
        void DeleteProduct();
        void GetProductInformation();
    }
}
