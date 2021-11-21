using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ShopHttpClient.Controllers
{
    public interface IShowcaseHttpController
    {
        void CreateShowcase(string nameShowcase, double volumeShowcase);
        void DeleteShowcase(int showcaseId);
        void PlaceProductOnShowcase(int productId, int showcaseId);
        void DeleteProductOnShowcase(int showcaseId, int productId);
        void EditeShowcase(int showcaseId, string showcaseName, double showcaseVolume);
        void EditeProductOnShowcase(int productId, int showcaseId, string productName, double productVolume);
        void GetShowcaseInformation();
    }
}
