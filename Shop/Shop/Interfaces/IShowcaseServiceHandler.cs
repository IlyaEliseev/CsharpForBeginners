using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IShowcaseServiceHandler
    {
        void CreateShowcase();
        void DeleteShowcase();
        void PlaceProductOnShowcase();
        void DeleteProductOnShowcase();
        void EditeShowcase();
        void EditeProductOnShowcase();
        void GetShowcaseInformation();
    }
}
