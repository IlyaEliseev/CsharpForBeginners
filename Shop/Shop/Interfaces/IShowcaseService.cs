using Shop.Models;

namespace Shop.Interfaces
{
    public interface IShowcaseService
    {
        Showcase Create(string showcaseName, double showcaseVolume);
        int GetShowcaseListCount();
        int GerProductShowcaseCount(int showcaseId);
        void PlaceShowcase(Showcase showcase);
        void DeleteShowcase(int showcaseId);
        Showcase GetShowcase(int showcaseId);
        bool CheckShowcaseCount(int showcaseId);
        void GetInformation();
        void EditShowcase(int showcaseId, string showcaseName, double showcaseVolume);
        bool CheckProductOnCurrentShowcase(int showcaseId);
        bool CheckShowcaseVolumeOverflow(int showcaseId, int productId, IProductService product);
        void CountShowcaseVolume(IProductService product, int showcaseId, int productId);
        void PlaceProduct(IProductService product, int productId, int showcaseId);
        void DeleteProduct(IProductService product, int productId, int showcaseId);
        void EditProduct(int productId, int showcaseId, string newProductName, double newProductVolume);
        bool CheckShowcaseAvailability();
        double GetShowcaseFreeSpace(int showcaseId);
    }
}
