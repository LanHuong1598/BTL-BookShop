﻿using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
   
    public class F_Book
    {
        MyDBContext context;
        public F_Book()
        {
            context = new MyDBContext();
        }
        public List<Book> getAll()
        {
            List<Book> ans = context.Books.ToList();
            return ans;
        }
        public Book GetBook(long id)
        {
            return context.Books.Find(id);
        }
    }
}