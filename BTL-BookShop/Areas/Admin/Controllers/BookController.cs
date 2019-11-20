using BTL_BookShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BTL_BookShop.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        // GET: Admin/Book
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new F_Book();
            var model = dao.ListAllByTag(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new F_Book().changeStatus(id);
            return Json( new
            {
                status = result
            });


        }
    }
}