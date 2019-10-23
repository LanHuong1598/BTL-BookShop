﻿using BTL_BookShop.Models.Function;
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
        public ActionResult Search(string txt)
        {
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            var model = new F_Book().getAll().Where(x => x.Name.Contains(txt)).ToList();
            ViewBag.Book = model;
            return View();
        }
    }
}