using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_BookShop.Models.Entities;
namespace BTL_BookShop.Models.Function
{
    public class F_User
    {
        private MyDBContext context;
        public F_User()
        {
            context = new MyDBContext();
        }
    }
}