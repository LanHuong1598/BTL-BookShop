using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
    public class F_CategoryBook
    {
        private MyDBContext context;

        public F_CategoryBook()
        {
            context = new MyDBContext();
        }
        public IQueryable<CategoryBook> List
        {
            get { return context.CategoryBooks; }
        }
        public List<CategoryBook> getAll()
        {
            List<CategoryBook> ans = context.CategoryBooks.ToList();
            return ans;
        }
    }
}