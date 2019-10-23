using BTL_BookShop.Models.Function;
using BTL_BookShop.Models.Function;
using BTL_BookShop.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_BookShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Cart()
        {
            var model = new F_cart().ListCartItems.ToList();
            ViewBag.Cart = model;
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            return View();
        }
        public ActionResult Menu()
        {
            var ds = new F_cart().ListCartItems.ToList();
            return PartialView(ds);
        }
        public ActionResult Search()
        {
            var model = new F_cart().ListCartItems.ToList();
            ViewBag.cart = model;
            return View(model);
        }
    }
}