using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public interface IProductOnShowcaseRepository : IRepository<Product>
    {
        Product GetProduct(int productId);
    }
}
