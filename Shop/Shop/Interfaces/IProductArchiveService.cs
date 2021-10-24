
namespace Shop.Interfaces
{
    public interface IProductArchiveService
    {
        void ArchivateProduct(int productId, int showcaseId, IShowcaseService showcaseService);
        void GetArchiveInformation();
        void UnArchivateProduct(int productId, IShowcaseService showcaseService);
        void DeleteArchiveProduct(int productId);
        int GetArchiveProductCount();
    }
}
