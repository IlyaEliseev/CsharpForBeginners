using Shop.Models;
using System.Collections.Generic;

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
        IEnumerable<Product> GetArchiveProducts();
        void AddDataFromFile(Product archiveProduct);
    }
}
