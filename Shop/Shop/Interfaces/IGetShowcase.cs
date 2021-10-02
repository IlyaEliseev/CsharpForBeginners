using Shop.Models;

namespace Shop.Interfaces
{
    interface IGetShowcase
    {
        Showcase GetShowcase(int showcaseId);
    }
}
