using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_BookShop.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        // GET: Admin/Book
        public ActionResult Index()
        {
            var model1 = Session["User"] as User;
            ViewBag.user = model1;
            F_Book book = new F_Book();
            var model = book.getAll();
            return View(model);
        }

        [HttpGet] 
        public ActionResult Create()
        {
            var model1 = Session["User"] as User;
            ViewBag.user = model1;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book bk)
        {
            var model1 = Session["User"] as User;
            ViewBag.user = model1;
            if (ModelState.IsValid)
            {
                var book = new F_Book();
                int res = book.Insert(bk);
                if (res > 0) return RedirectToAction("Index");
                else ModelState.AddModelError("Notice", "Them khong thanh cong");

            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Update(int ID)
        {
            var model1 = Session["User"] as User;
            ViewBag.user = model1;
            var bk = new F_Book().ViewDetail(ID);
            return View(bk);

        }
        [HttpPost]
        public ActionResult Update(Book bk)
        {
            var model1 = Session["User"] as User;
            ViewBag.user = model1;
            if (ModelState.IsValid)
            {
                var book = new F_Book();
                int res = book.Update(bk);
                if (res > 0) return RedirectToAction("Index");
                else ModelState.AddModelError("Notice", "Them khong thanh cong");

            }
            return View("Index");

        }
   


    }
}