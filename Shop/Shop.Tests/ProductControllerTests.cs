using Shop.Controllers;
using Shop.Services;
using Xunit;

namespace Shop.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void CreateProduct_ProductListIsNotEmpty()
        {
            // arrange
            var notifyService = new NotifyService();
            var checkService = new CheckService();
            var productController = new ProductController(notifyService, checkService);
            var name = "111";
            var volume = 100;

            // act
            productController.CreateProduct(name, volume);

            // assert
            Assert.True(productController.GetProductCount() > 0);
        }

        [Fact]
        public void CreateProduct_InputParametrsEqualOutput()
        {
            // arrange
            var notifyService = new NotifyService();
            var checkService = new CheckService();
            var productController = new ProductController(notifyService, checkService); ;
            string name = "111";
            var volume = 100;

            // act
            productController.CreateProduct(name, volume);
            var product = productController.GetProduct(1);

            // assert
            Assert.Equal(name, product.Name);
            Assert.Equal(volume, product.Volume);
        }
    }
}
