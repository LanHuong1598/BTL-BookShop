using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Functions
{
    public class F_cart
    {
        private MyDBContext content;
        public F_cart()
        {
            content = new MyDBContext();
        }
        public IQueryable<CartItem> ListCartItems
        {
            get { return content.CartItems; }
        }
        public CartItem FindCartItem(long ma)
        {
            CartItem temp = content.CartItems.Find(ma);
            return temp;
        }
        public long? Insert(CartItem model)
        {
            CartItem temp = content.CartItems.Find(model.ID);
            if (temp != null)
            {
                return null;
            }
            else
            {
                content.CartItems.Add(model);
                content.SaveChanges();
                return model.ID;
            }
        }
        public long? Update(CartItem model)
        {
            CartItem temp = content.CartItems.Find(model.ID);
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
        public long? Delete(CartItem model)
        {
            CartItem temp = content.CartItems.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                content.CartItems.Remove(model);
                content.SaveChanges();
                return model.ID;
            }
        }
        public List<CartItem> getAll()
        {
            List<CartItem> ans = content.CartItems.ToList();
            return ans;
        }


    }
}