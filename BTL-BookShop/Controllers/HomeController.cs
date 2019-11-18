using BTL_BookShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Functions;
using BTL_BookShop.Common;

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
        [ChildActionOnly]
        public ActionResult _HeaderTopArea()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            F_TopMenu f_TopMenu = new F_TopMenu();
            var model = f_TopMenu.withNullSession();
            if (session == null)
            {
                model = f_TopMenu.withNullSession();
            }
            else
            {
                model = f_TopMenu.withSession(session.UserName,session.GroupID);
            }
         
            return PartialView(model);
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
            var f_user = new F_User();
            var result = f_user.Login_Test(model.UserName, Encryptor.MD5Hash(model.Password));
            if (result)
            {
                var user = f_user.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                var userSession = new UserLogin();
                userSession.UserName = user.UserName;
                userSession.UserID = user.ID;
                userSession.GroupID = user.GroupID;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                if (user.GroupID == "ADMIN")
                {
                    return Redirect("/Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng");
            }
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}