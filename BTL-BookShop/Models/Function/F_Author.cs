using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_BookShop.Models.Entities;
using BTL_BookShop;

namespace BTL_BookShop.Models.Function
{
    public class F_Author
    {
        private MyDBContext context;

        public List<Author> getAll()
        {
            List<Author> ans = context.Authors.ToList();
            return ans;
        }

        public F_Author()
        {
            context = new MyDBContext();
        }

        public IQueryable<Author> DSDM
        {
            get { return context.Authors; }
        }

        public Author FindEntity(long ma)
        {
            Author dbE = context.Authors.Find(ma);
            return dbE;
        }

        public long? Insert(Author model)
        {
            Author temp = context.Authors.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Authors.Add(model);
                context.SaveChanges();
                return model.ID;
            }
        }

        public long? Update(Author model)
        {
            Author temp = context.Authors.Find(model.ID);
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
        public long? Delete(Author model)
        {
            Author temp = context.Authors.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Authors.Remove(model);
                context.SaveChanges();
                return model.ID;
            }
        }
    }
}