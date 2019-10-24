using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
    public class F_Book
    {
        MyDBContext context = null;
        public F_Book()
        {
            context = new MyDBContext();
        }
        public IQueryable<Book> ListBooks
        {
            get { return context.Books; }
        }
        public List<Book> getAll()
        {
            List<Book> ans = context.Books.ToList();
            return ans;
        }
        public Book FindBook(long ma)
        {
            Book temp = context.Books.Find(ma);
            return temp;
        }
        public long? Insert(Book model)
        {
            Book temp = context.Books.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Books.Add(model);
                context.SaveChanges();
                return model.ID;
            }
        }

        internal object FindEntity(long id)
        {
            throw new NotImplementedException();
        }

        public long? Update(Book model)
        {
            Book temp = context.Books.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                temp = model;
                context.SaveChanges();
                return model.ID;
            }
        }
        public long? Delete(Book model)
        {
            Book temp = context.Books.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Books.Remove(model);
                context.SaveChanges();
                return model.ID;
            }
        }
        

    }
}