using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ShopHttpClient.HttpModels
{
    internal class HttpResponce
    {
        public int ProductId { get; set; }
        public int ShowcaseId { get; set; }
        public int ProductInShowcaseId { get; set; }
        public int ProductInArchiveId { get; set; }
    }
}
