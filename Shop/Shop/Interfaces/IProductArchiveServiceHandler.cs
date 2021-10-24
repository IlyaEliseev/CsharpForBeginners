
namespace Shop.Interfaces
{
    public interface IProductArchiveServiceHandler
    {
        void ArchivateProduct();
        void DeleteArchiveProduct();
        void GetArchiveInformation();
        void UnArchivateProduct();
        bool CheckArchiveAvailability();
    }
}
