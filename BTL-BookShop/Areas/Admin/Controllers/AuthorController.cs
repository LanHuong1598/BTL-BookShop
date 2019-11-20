using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BTL_BookShop.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        // GET: Admin/Author
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            F_Author fauthor = new F_Author();
            var model = fauthor.ListAllPaging(page,pageSize); 
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(new F_Author().Form());
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author us)
        {
            if (us.Image.Contains("Data"))
            {
                us.Image.Replace("Data/Images", "Assets/Client/images/Author");
            }
            if (ModelState.IsValid)
            {
                var fauthor = new F_Author();
                int res = fauthor.Insert(us);
                if (res > 0) return RedirectToAction("Index");
                else ModelState.AddModelError("Notice", "Them khong thanh cong");

            }
            return View("Index");

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            ViewBag.Type = new SelectList(new F_Author().Form());
            var author = new F_Author().ViewDetail(ID);
            return View(author);

        }
        [HttpPost]
        public ActionResult Update(Author us)
        {
           
            if (ModelState.IsValid)
            {
                var fauthor = new F_Author();
                int res = fauthor.Update(us);
                if (res > 0) return RedirectToAction("Index");
                else ModelState.AddModelError("Notice", "Them khong thanh cong");
            }

            return View("Index");

        }
        public ActionResult Delete(long ID)
        {

            var fauthor = new F_Author();
            long? res = fauthor.Delete(fauthor.FindEntity(ID));
            if (res > 0) return RedirectToAction("Index");
            else ModelState.AddModelError("Notice", "Them khong thanh cong");
            return View("Index");

        }


    }
}