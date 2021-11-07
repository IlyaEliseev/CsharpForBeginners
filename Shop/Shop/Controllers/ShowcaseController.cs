using Shop.DAL;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShowcaseController
    {
        public IUnitOfWork UnitOfWork { get; }

        public NotifyService NotifyService { get; }
        public CheckService CheckService { get; }

        public ShowcaseController(NotifyService notifyService, CheckService checkService)
        {
            NotifyService = notifyService;
            CheckService = checkService;
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        

    }
}
