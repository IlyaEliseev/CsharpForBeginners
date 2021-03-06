using Newtonsoft.Json;
using Shop.ShopHttpServer.Controllers;
using Shop.ShopModels.Models;
using System;
using System.Linq;
using System.Net;

namespace Shop.ShopHttpServer.HttpResponceControllers
{
    internal class ProductArchiveHttpController
    {
        public ProductArchiveHttpController(IProductArchiveController productArchiveController, IPathController productArchivePathController)
        {
            ProductArchiveController = productArchiveController;
            ProductArchivePathController = productArchivePathController;
        }

        public IProductArchiveController ProductArchiveController { get; set; }
        public IPathController ProductArchivePathController { get; set; }

        public void StartController(HttpListenerContext context, string path)
        {
            if (path == ProductArchivePathController.Path)
            {
                switch (context.Request.HttpMethod)
                {
                    case "GET":
                        GetArchiveInformation(context);
                        break;
                    case "POST": //Archivate product
                        ArchivateProduct(context);
                        break;
                    case "PATCH": // Unarchivate product
                        UnArchivateProduct(context);
                        break;
                }
            }

            if (path == ProductArchivePathController.FindPath(path) && context.Request.HttpMethod == "DELETE")
            {
                DeleteArchiveProduct(context);
            }
        }


        private void ArchivateProduct(HttpListenerContext context)
        {
            var archivePostData = StreamDataController.GetRequestDataBody<HttpResponceModel>(context);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            var productId = archivePostData.ProductInShowcaseId;
            var showcaseId = archivePostData.ShowcaseId;
            ProductArchiveController.ArchivateProduct(productId, showcaseId);
            ProductArchivePathController.AddPath(ProductArchivePathController.Path + $"/{ProductArchiveController.GetArchiveProductCount()}");
            StreamDataController.SetResponce("Product is archivate", context);
            Console.WriteLine(archivePostData);
        }

        private void UnArchivateProduct(HttpListenerContext context)
        {
            var archivePatchData = StreamDataController.GetRequestDataBody<HttpResponceModel>(context);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            var productId = archivePatchData.ProductInArchiveId;
            ProductArchiveController.UnArchivateProduct(productId);
            StreamDataController.SetResponce("Product is unarchivate", context);
            Console.WriteLine(archivePatchData);
        }

        private void DeleteArchiveProduct(HttpListenerContext context)
        {
            var productId = int.Parse(context.Request.Url.Segments.Last());
            ProductArchiveController.DeleteArchiveProduct(productId);
            StreamDataController.SetResponce("Product is delete", context);
        }

        private void GetArchiveInformation(HttpListenerContext context)
        {
            var archiveProducts = ProductArchiveController.GetArchiveProducts();
            var responceBody = JsonConvert.SerializeObject(archiveProducts, Formatting.Indented);
            StreamDataController.SetResponce(responceBody, context);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}
