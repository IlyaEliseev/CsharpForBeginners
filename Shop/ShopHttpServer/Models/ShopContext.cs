using System.Collections.Generic;

namespace Shop.ShopHttpServer.Models
{
    public class ShopContext
    {
        public List<Product> ProductContext { get; private set; }
        public List<Showcase> ShowcaseContext { get; private set; }
        public List<Product> ProductOnShowcaseContext { get; private set; }
        public List<Product> ArchiveContext { get; private set; }

        public ShopContext()
        {
            ProductContext = new List<Product>();
            ShowcaseContext = new List<Showcase>();
            ProductOnShowcaseContext = new List<Product>();
            ArchiveContext = new List<Product>();
        }
    }
}
