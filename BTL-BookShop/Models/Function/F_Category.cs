using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
   
    public class F_Category
    {
        MyDBContext context = null;
        public F_Category()
        {
            context = new MyDBContext();
        }
        public List<Category> getAll()
        {
            List<Category> ans = context.Categories.ToList();
            return ans;
        }
    }

}