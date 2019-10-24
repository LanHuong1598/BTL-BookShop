﻿using BTL_BookShop.Models.Function;
using BTL_BookShop.Models.Functions;
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

        public ActionResult Product(long id)
        {
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            var model = new F_Book().FindEntity(id);
            ViewBag.Book = model;
            return View();
        }
        public ActionResult Search(string txt)
        {
            var model = new F_Book().getAll().Where(x => x.Name.Contains(txt)).ToList();
            ViewBag.Book = model;
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            
            return View();
        }

    }
}