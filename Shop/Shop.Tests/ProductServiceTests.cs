using Shop.Services;
using Xunit;

namespace Shop.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void CreateProduct_ProductListIsNotEmpty()
        {
            // arrange
            var notifyService = new NotifyService();
            var productService = new ProductService(notifyService);

            var name = "111";
            var volume = 100;
            productService.Create(name, volume);

            // assert
            Assert.True(productService.GetProductsCount() > 0);
        }

        [Fact]
        public void CreateProduct_InputParametrsEqualOutput()
        {
            // arrange
            var notifyService = new NotifyService();
            var productService = new ProductService(notifyService);
            
            string name = "111";
            var volume = 100;

            // act
            productService.Create(name, volume);
            var product = productService.GetProduct(1);
            
            // assert
            Assert.Equal(name, product.Name);
            Assert.Equal(volume, product.Volume);
        }
    }
}
