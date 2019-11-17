using BTL_BookShop.Areas.Admin.Models;
using BTL_BookShop.Common;
using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_BookShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
       

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var f_user = new F_User();
                var result = f_user.Login_Test(model.UserName, model.Password);
                if (result)
                {
                    var user = f_user.getByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID;
                    Session.Add(CommonConstants.USER_SESSION,userSession);
                }
                else
                {

                }
            }
            else
            {
                ModelState.AddModelError("", "Dang nhap khong dunng");
            }
            return View("Index");

        }
    }
}