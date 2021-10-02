using Shop.Models;
namespace Shop.Interfaces
{
    interface ICreateShowcase
    {
        Showcase Create(string showcaseName, double showcaseVolume);
    }
}
