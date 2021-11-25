using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ShopHttpServer.Controllers
{
    public interface IUriPathController
    {
        string Path { get; }
        void AddUri(string uri);
        string FindUri(string uri);
    }
}
