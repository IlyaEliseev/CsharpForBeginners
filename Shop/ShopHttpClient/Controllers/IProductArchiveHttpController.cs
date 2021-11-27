
namespace Shop.ShopHttpClient.Controllers
{
    public interface IProductArchiveHttpController
    {
        void ArchivateProduct(int productId, int showcaseId);
        void GetArchiveInformation();
        void UnArchivateProduct(int productId);
        void DeleteArchiveProduct(int productId);

    }
}
