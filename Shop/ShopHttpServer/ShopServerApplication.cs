using Newtonsoft.Json;
using Shop.ShopHttpServer.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using Shop.ShopHttpServer.Controllers;
using System.Linq;

namespace Shop.ShopHttpServer
{
    internal class ShopServerApplication
    {
        private readonly HttpListener _httpListener;
        public IProductController ProductController { get; }
        public IShowcaseController ShowcaseController { get; }
        public IUriPathController ProductUrlPathController { get; }
        public IUriPathController ShowcaseUriPathController { get; }
        public IUriPathController ProductOnShowcaseUriPathController { get; }

        public ShopServerApplication(HttpListener httpListener, IProductController productController, IShowcaseController showcaseController, 
                                     IUriPathController productUrlPathController, IUriPathController showcaseUriPathController, IUriPathController productOnShowcaseUriPathController)
        {
            _httpListener = httpListener;
            ProductController = productController;
            ShowcaseController = showcaseController;
            ProductUrlPathController = productUrlPathController;
            ShowcaseUriPathController = showcaseUriPathController;
            ProductOnShowcaseUriPathController = productOnShowcaseUriPathController;
        }

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

                //Products http methods
                if (path == ProductUrlPathController.Path)
                {
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            var products = ProductController.GetProducts();
                            responceBody = JsonConvert.SerializeObject(products, Formatting.Indented);
                            SetResponce(responceBody, context);
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            break;
                        case "POST":
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            var productPostData = GetRequestDataBody<Product>(context);
                            productName = productPostData.Name;
                            productVolume = productPostData.Volume;
                            ProductController.CreateProduct(productName, productVolume);
                            responceBody = "Product is create";
                            ProductUrlPathController.AddUri(ProductUrlPathController.Path + $"/{ProductController.GetProductCount()}");
                            SetResponce(responceBody, context);
                            Console.WriteLine(productPostData);
                            break;
                        case "PUT":
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            var productPutData = GetRequestDataBody<Product>(context);
                            productId = productPutData.IdInProductList;
                            productName = productPutData.Name;
                            productVolume = productPutData.Volume;
                            ProductController.EditProduct(productId, productName, productVolume);
                            responceBody = "Product is edit";
                            SetResponce(responceBody, context);
                            Console.WriteLine(productPutData);
                            break;
                        default:
                            break;
                    }
                }
                
                //Products http delete method
                if (path == ProductUrlPathController.FindUri(path))
                {
                    switch (request.HttpMethod)
                    {
                        case "DELETE":
                            productId = int.Parse(request.Url.Segments.Last());
                            ProductController.DeleteProduct(productId);
                            responceBody = "Product is delete";
                            //ProductController.DeleteUri($"/app/product/{productId}");
                            SetResponce(responceBody, context);
                            break;
                    }
                }

                //Showcases http methods
                if (path == ShowcaseUriPathController.Path)
                {
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            var showcases = ShowcaseController.GetShowcases();
                            responceBody = JsonConvert.SerializeObject(showcases, Formatting.Indented);
                            SetResponce(responceBody, context);
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            break;
                        case "POST":
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            var showcasePostData = GetRequestDataBody<Showcase>(context);
                            showcaseName = showcasePostData.Name;
                            showcaseVolume = showcasePostData.Volume;
                            ShowcaseController.CreateShowcase(showcaseName, showcaseVolume);
                            ShowcaseUriPathController.AddUri(ShowcaseUriPathController.Path + $"/{ShowcaseController.GetShowcaseCount()}");
                            responceBody = "Showcase is create";
                            SetResponce(responceBody, context);
                            Console.WriteLine(showcasePostData);
                            break;
                        case "PUT":
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            var showcasePutData = GetRequestDataBody<Showcase>(context);
                            showcaseId = showcasePutData.Id;
                            showcaseName = showcasePutData.Name;
                            showcaseVolume = showcasePutData.Volume;
                            ShowcaseController.EditeShowcase(showcaseId, showcaseName, showcaseVolume);
                            responceBody = "Showcase is edit";
                            SetResponce(responceBody, context);
                            Console.WriteLine(showcasePutData);
                            break;
                        case "PATCH":
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            var showcasePatchData = GetRequestDataBody<HttpResponce>(context);
                            showcaseId = showcasePatchData.ShowcaseId;
                            productId = showcasePatchData.ProductId;
                            ShowcaseController.PlaceProductOnShowcase(productId, showcaseId);
                            ProductOnShowcaseUriPathController.AddUri(ShowcaseUriPathController.Path + $"/{showcaseId}" + $"/product/{ShowcaseController.GetProductCountOnShowcase(showcaseId)}");
                            responceBody = "Product place on showcase";
                            SetResponce(responceBody, context);
                            Console.WriteLine(showcasePatchData);
                            break;
                        default:
                            break;
                    }
                }

                //Showcases http delete method
                if (path == ShowcaseUriPathController.FindUri(path))
                {
                    switch (request.HttpMethod)
                    {
                        case "DELETE":
                            showcaseId = int.Parse(request.Url.Segments.Last());
                            ShowcaseController.DeleteShowcase(showcaseId);
                            responceBody = "Product is delete";
                            SetResponce(responceBody, context);
                            break;
                    }
                }

                //Product on showcase http methods
                if (path == ProductOnShowcaseUriPathController.Path)
                {
                    switch (request.HttpMethod)
                    {
                        case "PUT": // edit prodduct on showcase
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            var productOnShowcasePutData = GetRequestDataBody<HttpResponce>(context);
                            showcaseId = productOnShowcasePutData.ShowcaseId;
                            productId = productOnShowcasePutData.ProductInShowcaseId;
                            productName = productOnShowcasePutData.ProductName;
                            productVolume = productOnShowcasePutData.ProductVolume;
                            ShowcaseController.EditeProductOnShowcase(productId, showcaseId, productName, productVolume);
                            responceBody = "Product on showcase is edit";
                            SetResponce(responceBody, context);
                            Console.WriteLine(productOnShowcasePutData);
                            break;
                        default:
                            break;
                    }
                }

                //Product on showcase http delete method
                if (path == ProductOnShowcaseUriPathController.FindUri(path))
                {
                    switch (request.HttpMethod)
                    {
                        case "DELETE":
                            string stringPAth = request.Url.Segments[3];
                            showcaseId = int.Parse(stringPAth.TrimEnd('/'));
                            productId = int.Parse(request.Url.Segments.Last());
                            ShowcaseController.DeleteProductOnShowcase(showcaseId, productId);
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
