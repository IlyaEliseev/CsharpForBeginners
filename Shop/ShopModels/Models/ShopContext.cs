using System.Collections.Generic;

namespace Shop.ShopModels.Models
{
    public class ShopContext
    {
        public List<Product> ProductContext { get; set; }
        public List<Showcase> ShowcaseContext { get; set; }
        public List<Product> ProductOnShowcaseContext { get; set; }
        public List<Product> ArchiveContext { get; set; }

        public ShopContext()
        {
            ProductContext = new List<Product>();
            ShowcaseContext = new List<Showcase>();
            ProductOnShowcaseContext = new List<Product>();
            ArchiveContext = new List<Product>();
        }
    }
}
