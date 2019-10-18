using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Function;
namespace BTL_BookShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            List<User> DS_User = new F_User().DS_User.ToList();
            return View(DS_User);
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}