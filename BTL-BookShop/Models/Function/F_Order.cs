using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
    public class F_Order
    {
        private MyDBContext context;

        public List<Order> getAll()
        {
            List<Order> ans = context.Orders.ToList();
            return ans;
        }

        public F_Order()
        {
            context = new MyDBContext();
        }

        public IQueryable<Order> DSDM
        {
            get { return context.Orders; }
        }

        public Order FindEntity(long ma)
        {
            Order dbE = context.Orders.Find(ma);
            return dbE;
        }

        public long? Insert(Order model)
        {
            Order temp = context.Orders.Find(model.ID);
            if (temp != null)
            {
                return null;
            }
            else
            {
                context.Orders.Add(model);
                context.SaveChanges();
                return model.ID;
            }
        }

        public long? Update(Order model)
        {
            Order temp = context.Orders.Find(model.ID);
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
        public long? Delete(Order model)
        {
            Order temp = context.Orders.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Orders.Remove(model);
                context.SaveChanges();
                return model.ID;
            }
        }






    }
}