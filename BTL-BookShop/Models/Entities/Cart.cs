using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Entities
{
    public class GioHangViewModel
    {
        public Cart Cart { get; set; }
    }
    public class Cart
    {

        public Cart()
        {
            ListItem = new List<CartItem>();
        }
        public List<CartItem> ListItem { get; set; }
        public void AddToCart(CartItem item)
        {
            if (ListItem.Where(s => s.ItemID.Equals(item.ItemID)).Any())
            {
                var myItem = ListItem.Single(s => s.ItemID.Equals(item.ItemID));
                myItem.Quantity += item.Quantity;
            }
            else
            {
                ListItem.Add(item);
            }
        }
        public bool XoaSanPham(int lngProductSellID)
        {
            CartItem existsItem = ListItem.Where(x => x.ItemID == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                ListItem.Remove(existsItem);
            }
            return true;
        }
        public bool CapNhatSoLuong(int lngProductSellID, int intQuantity)
        {
            CartItem existsItem = ListItem.Where(x => x.ItemID == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                existsItem.Quantity = intQuantity;
            }
            return true;
        }
        public bool GioHangRong()
        {
            ListItem.Clear();
            return true;
        }

    }
}