using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Functions
{
    public class F_Book
    {
        private MyDBContext content;
        public F_Book()
        {
            content = new MyDBContext();
        }
        public IQueryable<Book> ListBooks
        {
            get { return content.Books; }
        }
        public Book FindBook(long ma)
        {
            Book temp = content.Books.Find(ma);
            return temp;
        }
        public long? Insert(Book model)
        {
            Book temp = content.Books.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                content.Books.Add(model);
                content.SaveChanges();
                return model.ID;
            }
        }
        public long? Update(Book model)
        {
            Book temp = content.Books.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                temp = model;
                content.SaveChanges();
                return model.ID;
            }
        }
        public long? Delete(Book model)
        {
            Book temp = content.Books.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                content.Books.Remove(model);
                content.SaveChanges();
                return model.ID;
            }
        }
        public List<Book> getAll()
        {
            List<Book> ans = content.Books.ToList();
            return ans;
        }
    }
}