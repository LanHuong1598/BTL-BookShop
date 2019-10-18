using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_BookShop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}