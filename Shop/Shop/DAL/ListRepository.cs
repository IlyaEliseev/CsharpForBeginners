using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Services;
using Shop.Interfaces;

namespace Shop.DAL
{
    public class ListRepository
    {
        private List<Product> _products;
        public IProductService ProductService { get; private set; }

        public ListRepository(IProductService productService)
        {
            _products = new List<Product>();
            ProductService = productService;
        }

    }
}
