using Shop.Models;

namespace Shop.Interfaces
{
    public interface ICreateShowcase
    {
        Showcase Create(string showcaseName, double showcaseVolume);
    }
}
