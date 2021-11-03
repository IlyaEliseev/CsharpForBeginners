
namespace Shop.Interfaces
{
    public interface IShowcaseServiceHandler
    {
        void CreateShowcase(string nameShowcase, double volumeShowcase);
        void DeleteShowcase(int showcaseId);
        void PlaceProductOnShowcase(int productId, int showcaseId, IProductController productControllery);
        void DeleteProductOnShowcase(int showcaseId, int productId);
        void EditeShowcase(int showcaseId, string showcaseName, double showcaseVolume);
        void EditeProductOnShowcase(int productId, int showcaseId, string productName, double productVolume);
        void GetShowcaseInformation();
    }
}
