using BTL_BookShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_BookShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        
        protected override void OnActionExecuting (ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");

            }
            else
            {
                if(session.GroupID == "MEMBER") filterContext.Result = new RedirectResult("/Home/Index");
            }

            base.OnActionExecuting(filterContext);  
        }
    }
}