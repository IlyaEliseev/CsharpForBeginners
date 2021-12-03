using Newtonsoft.Json;
using Shop.ShopHttpServer.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using Shop.ShopHttpServer.Controllers;
using System.Linq;
using Shop.ShopModels.Models;
using Shop.ShopHttpServer.HttpResponceControllers;

namespace Shop.ShopHttpServer
{
    internal class ShopServerApplication
    {
        public ShopServerApplication(HttpListener httpListener, IProductController productController, IShowcaseController showcaseController, IProductArchiveController productArchiveController,
                                     IPathController productPathController, IPathController showcasePathController, IPathController productOnShowcasePathController, IPathController productArchivePathController)
        {
            _httpListener = httpListener;
            ProductController = productController;
            ShowcaseController = showcaseController;
            ProductArchiveController = productArchiveController;
            ProductPathController = productPathController;
            ShowcasePathController = showcasePathController;
            ProductOnShowcasePathController = productOnShowcasePathController;
            ProductArchivePathController = productArchivePathController;
            ProductHttpController = new ProductHttpController(productController, new StreamDataController(), productPathController);
            ShowcasetHttpController = new ShowcaseHttpController(showcasePathController, productOnShowcasePathController, showcaseController);
        }

        private readonly HttpListener _httpListener;
        public IProductController ProductController { get; }
        public IShowcaseController ShowcaseController { get; }
        public IProductArchiveController ProductArchiveController { get; }
        public ProductHttpController ProductHttpController { get; set; }
        public ShowcaseHttpController ShowcasetHttpController { get; set; }
        public IPathController ProductPathController { get; }
        public IPathController ShowcasePathController { get; }
        public IPathController ProductOnShowcasePathController { get; }
        public IPathController ProductArchivePathController { get; }

        internal void Run()
        {
            _httpListener.Start();
            Console.WriteLine("Server started");

            while (true)
            {
                var context = _httpListener.GetContext();
                var responce = context.Response;
                var request = context.Request;
                string responceBody;
                int showcaseId;
                int productId;
                string productName;
                double productVolume;
                string showcaseName;
                double showcaseVolume;
                var path = request.Url.PathAndQuery;

                ProductHttpController.StartController(context, path);
                ShowcasetHttpController.StartController(context, path);

                //Archive http methods
                if (path == ProductArchivePathController.Path)
                {
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            var archiveProducts = ProductArchiveController.GetArchiveProducts();
                            responceBody = JsonConvert.SerializeObject(archiveProducts, Formatting.Indented);
                            SetResponce(responceBody, context);
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            break;
                        case "POST": //Archivate product
                            var archivePostData = GetRequestDataBody<HttpResponceModel>(context);
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            productId = archivePostData.ProductInShowcaseId;
                            showcaseId = archivePostData.ShowcaseId;
                            ProductArchiveController.ArchivateProduct(productId, showcaseId);
                            responceBody = "Product is archivate";
                            ProductArchivePathController.AddPath(ProductArchivePathController.Path + $"/{ProductArchiveController.GetArchiveProductCount()}");
                            SetResponce(responceBody, context);
                            Console.WriteLine(archivePostData);
                            break;
                        case "PATCH": // Unarchivate product
                            var archivePatchData = GetRequestDataBody<HttpResponceModel>(context);
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            productId = archivePatchData.ProductInArchiveId;
                            ProductArchiveController.UnArchivateProduct(productId);
                            responceBody = "Product is unarchivate";
                            SetResponce(responceBody, context);
                            Console.WriteLine(archivePatchData);
                            break;
                        default:
                            break;
                    }

                }

                //Delete product in archive
                if (path == ProductArchivePathController.FindPath(path))
                {
                    switch (request.HttpMethod)
                    {
                        case "DELETE":
                            //string stringPAth = request.Url.Segments[3];
                            //showcaseId = int.Parse(stringPAth.TrimEnd('/'));
                            productId = int.Parse(request.Url.Segments.Last());
                            ProductArchiveController.DeleteArchiveProduct(productId);
                            responceBody = "Product is delete";
                            SetResponce(responceBody, context);
                            break;
                    }
                }

                responce.Close();
            }
            
        }

        public static T GetRequestDataBody<T>(HttpListenerContext context)
        {
            string requestBody;
            using (var reader = new StreamReader(context.Request.InputStream,
                                     context.Request.ContentEncoding))
            {
                requestBody = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<T>(requestBody);
        }

        public static void SetResponce(string responce, HttpListenerContext context)
        {
            var streamWrite = context.Response.OutputStream;
            var bytes = Encoding.UTF8.GetBytes(responce);
            streamWrite.Write(bytes, 0, bytes.Length);
            streamWrite.Close();
        }
    }
}
