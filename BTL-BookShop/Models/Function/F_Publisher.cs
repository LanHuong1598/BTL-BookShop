using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
    public class F_Publisher
    {
        private MyDBContext context;

        public List<Publisher> getAll()
        {
            List<Publisher> ans = context.Publishers.ToList();
            return ans;
        }

        public F_Publisher()
        {
            context = new MyDBContext();
        }

        public IQueryable<Publisher> DSDM
        {
            get { return context.Publishers; }
        }

        public Publisher FindEntity(long ma)
        {
            Publisher dbE = context.Publishers.Find(ma);
            return dbE;
        }

        public long? Insert(Publisher model)
        {
            Publisher temp = context.Publishers.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Publishers.Add(model);
                context.SaveChanges();
                return model.ID;
            }
        }

        public long? Update(Publisher model)
        {
            Publisher temp = context.Publishers.Find(model.ID);
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
        public long? Delete(Publisher model)
        {
            Publisher temp = context.Publishers.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Publishers.Remove(model);
                context.SaveChanges();
                return model.ID;
            }
        }






    }
}