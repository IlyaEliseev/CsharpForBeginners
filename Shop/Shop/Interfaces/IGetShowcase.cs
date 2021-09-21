using Shop.Models;

namespace Shop.Interfaces
{
    interface IGetShowcase
    {
        Showcase Get(int showcaseId);
    }
}
