
namespace Shop.Controllers
{
    public interface IProductArchiveController
    {
        void ArchivateProduct(int productId, int showcaseId);
        void GetArchiveInformation();
        void UnArchivateProduct(int productId);
        void DeleteArchiveProduct(int productId);
        int GetArchiveProductCount();
        bool CheckArchiveAvailability();
    }
}
