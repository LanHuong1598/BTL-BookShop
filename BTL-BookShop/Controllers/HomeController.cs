using BTL_BookShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Functions;

namespace BTL_BookShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            ViewBag.ListBook = new F_Book().getAll();
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

        public PartialViewResult RenderModal_Item()
        {
            return PartialView();
        }

        public ActionResult Login()
        {
            var model = new User();

            return View(model);
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            string TenDN = model.UserName;
            string MK = model.Password;
            
            List<User> Ds_User = new F_User().DS_User.ToList();
            
                User user = new User();
                user = new F_User().Login(TenDN, MK);
                if(user.GroupID=="Admin")
                {
                return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
           
            
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}