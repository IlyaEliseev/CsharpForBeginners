using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
