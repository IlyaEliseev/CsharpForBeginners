using Newtonsoft.Json;
using Shop.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using Shop.ShopHttpServer.Controllers;

namespace Shop.ShopHttpServer
{
    internal class ShopServerApplication
    {
        private readonly HttpListener _httpListener;
        public IProductController ProductController { get; }
        public ShopServerApplication(HttpListener httpListener, IProductController productController)
        {
            _httpListener = httpListener;
            ProductController = productController;
        }

        internal void Run()
        {
            _httpListener.Start();


            while (true)
            {
                var context = _httpListener.GetContext();
                var responce = context.Response;
                var request = context.Request;
                string responceBody = "";
                string requestBody = "";

                //Products http methods
                if (request.Url.PathAndQuery == "/app/product")
                {
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            var products = ProductController.GetProducts();
                            responceBody = JsonConvert.SerializeObject(products);
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            break;
                        case "POST":
                            responce.StatusCode = (int)HttpStatusCode.OK;
                            using (var reader = new StreamReader(request.InputStream,
                                     request.ContentEncoding))
                            {
                                requestBody = reader.ReadToEnd();
                            }

                            var product = JsonConvert.DeserializeObject<Product>(requestBody);
                            var productName = product.Name;
                            var productVolume = product.Volume;
                            ProductController.CreateProduct(productName, productVolume);
                            responceBody = "Product is create";
                            Console.WriteLine(requestBody);
                            break;
                        case "PUT":

                            break;
                        case "PATCH":

                            break;
                        case "DELETE":

                            break;

                        default:
                            break;
                    }
                }

                var streamWrite = context.Response.OutputStream;
                var bytes = Encoding.UTF8.GetBytes(responceBody);
                streamWrite.Write(bytes, 0, bytes.Length);
                streamWrite.Close();
            }

            _httpListener.Stop();
            _httpListener.Close();
        }
    }
}
