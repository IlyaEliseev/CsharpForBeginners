using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;
namespace Shop.Interfaces
{
    interface ICreateProduct
    {
        void Create(string productName, double volume);
    }
}
