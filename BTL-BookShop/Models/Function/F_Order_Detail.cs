using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
    public class F_Order_Detail
    {
        private MyDBContext context;

        public List<Order_Detail> getAll()
        {
            List<Order_Detail> ans = context.Order_Detail.ToList();
            return ans;
        }

        public F_Order_Detail()
        {
            context = new MyDBContext();
        }

        public IQueryable<Order_Detail> DSDM
        {
            get { return context.Order_Detail; }
        }

        public Order_Detail FindEntity(long ma)
        {
            Order_Detail dbE = context.Order_Detail.Find(ma);
            return dbE;
        }

        public long? Insert(Order_Detail model)
        {
            Order_Detail temp = context.Order_Detail.Find(model.ID);
            if (temp != null)
            {
                return null;
            }
            else
            {
                context.Order_Detail.Add(model);
                context.SaveChanges();
                return model.ID;
            }
        }

        public long? Update(Order_Detail model)
        {
            Order_Detail temp = context.Order_Detail.Find(model.ID);
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
        public long? Delete(Order_Detail model)
        {
            Order_Detail temp = context.Order_Detail.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Order_Detail.Remove(model);
                context.SaveChanges();
                return model.ID;
            }
        }


}
}