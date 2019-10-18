using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_BookShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ViewCart()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            return View();
        }
       
    }
}