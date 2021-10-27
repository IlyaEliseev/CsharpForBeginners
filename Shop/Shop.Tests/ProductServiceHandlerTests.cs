using Shop.Interfaces;
using Shop.Models;
using Shop.ServiceHandlers;
using Shop.Services;
using Xunit;

namespace Shop.Tests
{
    public class ProductServiceHandlerTests
    {
       

        [Fact]
        public void CreateProductAndTakeInLlist()
        {
            // arrange
            var notifyService = new NotifyService();
            var checkService = new CheckService();
            var productService = new ProductService(notifyService);
            //var productServiceHandler = new ProductServiceHandler(productService, notifyService, checkService);

            var name = "111";
            var volume = 100;

            // act
            productService.Create(name, volume);
            var product = productService.GetProduct(1);
            //productServiceHandler.CreateProduct();

            // assert
            Assert.Equal(name, product.Name);
            Assert.Equal(volume, product.Volume);
            Assert.True(productService.GetProductsCount() == 1);
        }
    }
}
