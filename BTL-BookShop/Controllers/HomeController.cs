using BTL_BookShop.Models.Function;
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
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            return View();
        }

        public PartialViewResult RenderNews()
        {
            F_Book book = new F_Book();
            var model = book.getAll();
            return PartialView(model);
        }
        public PartialViewResult RenderSale()
        {
            F_Book book = new F_Book();
            var model = book.getAll();
            return PartialView(model);
        }
        public PartialViewResult RenderMostBookPay()
        {
            F_Book book = new F_Book();
            var model = book.getAll();
            return PartialView(model);
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