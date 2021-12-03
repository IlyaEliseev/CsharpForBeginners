using Newtonsoft.Json;
using Shop.ShopHttpServer.Controllers;
using Shop.ShopModels.Models;
using System;
using System.Linq;
using System.Net;

namespace Shop.ShopHttpServer.HttpResponceControllers
{
    public class ProductHttpController
    {
        public ProductHttpController(IProductController productController, StreamDataController streamDataController, IPathController productPath)
        {
            ProductController = productController;
            ProductPathController = productPath;
        }

        public IProductController ProductController { get; set; }
        public IPathController ProductPathController { get; set; }

        public void StartController(HttpListenerContext context, string path)
        {
            if (path == ProductPathController.Path)
            {
                switch (context.Request.HttpMethod)
                {
                    case "GET":
                        GetProductInformation(context);
                        break;
                    case "POST":
                        CreateProduct(context);
                        break;
                    case "PUT":
                        EditProduct(context);
                        break;
                }
            }

            if (path == ProductPathController.FindPath(path))
            {
                switch (context.Request.HttpMethod)
                {
                    case "DELETE":
                        DeleteProduct(context);
                        break;
                }
            }
        }

        private void GetProductInformation(HttpListenerContext context)
        {
            var products = ProductController.GetProducts();
            var responceBody = JsonConvert.SerializeObject(products, Formatting.Indented);
            StreamDataController.SetResponce(responceBody, context);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
        }

        private void CreateProduct(HttpListenerContext context)
        {
            var productPostData = StreamDataController.GetRequestDataBody<ProductModel>(context);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            var productName = productPostData.Name;
            var productVolume = productPostData.Volume;
            ProductController.CreateProduct(productName, productVolume);
            ProductPathController.AddPath(ProductPathController.Path + $"/{ProductController.GetProductCount()}");
            StreamDataController.SetResponce("Product is create", context);
            Console.WriteLine(productPostData);
        }

        private void EditProduct(HttpListenerContext context) 
        {
            var productPutData = StreamDataController.GetRequestDataBody<ProductModel>(context);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            var productId = productPutData.IdInProductList;
            var productName = productPutData.Name;
            var productVolume = productPutData.Volume;
            ProductController.EditProduct(productId, productName, productVolume);
            StreamDataController.SetResponce("Product is edit", context);
            Console.WriteLine(productPutData);
        }

        private void DeleteProduct(HttpListenerContext context) 
        {
            var productId = int.Parse(context.Request.Url.Segments.Last());
            ProductController.DeleteProduct(productId);
            StreamDataController.SetResponce("Product is delete", context);
        }
    }
}
