using BTL_BookShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}