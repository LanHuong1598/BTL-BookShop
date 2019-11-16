using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Functions
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
        public Book FindBook(long ma)
        {
            Book temp = context.Books.Find(ma);
            return temp;
        }
        public int Insert(Book model)
        {
            context.Books.Add(new Book { Code = model.Code , Name = model.Name , Author = model.Author , Released = model.Released });
            int res = context.SaveChanges();
            return res;
        }

        internal object FindEntity(long id)
        {
            throw new NotImplementedException();
        }

        public int Update(Book model)
        {
            Book temp = context.Books.Find(model.ID);
            if (temp == null)
            {
                return 0;
            }
            else
            {
                temp = model;
                int res = context.SaveChanges();
                return res;
            }
        }
        public int Delete(int id)
        {
            Book temp = context.Books.Find(id);
            context.Books.Remove(temp);
            int res = context.SaveChanges();
            return res;
        }
        public List<Book> getAll()
        {
            List<Book> ans = context.Books.ToList();
            return ans;
        }
        public Book ViewDetail(int id)
        {
            Book res = context.Books.Find(id);
            return res;
        }

    }
}