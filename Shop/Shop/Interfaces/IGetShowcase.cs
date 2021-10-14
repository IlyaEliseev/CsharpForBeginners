using Shop.Models;

namespace Shop.Interfaces
{
    public interface IGetShowcase
    {
        Showcase GetShowcase(int showcaseId);
    }
}
