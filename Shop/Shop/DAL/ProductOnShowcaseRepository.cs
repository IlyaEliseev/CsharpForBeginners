using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class ProductOnShowcaseRepository : IProductOnShowcaseRepository
    {
        Product GetProduct(int productId);
    }
}
