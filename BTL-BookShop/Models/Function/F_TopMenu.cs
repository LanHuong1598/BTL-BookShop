using BTL_BookShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
    public class F_TopMenu
    {
        public F_TopMenu() { }
        public List<ItemTopMenu> withNullSession()
        {
            List<ItemTopMenu> temp = new List<ItemTopMenu>();
            ItemTopMenu item = new ItemTopMenu();
            item.Name = "Đăng nhập";
            item.Link = "/Home/Login";
            temp.Add(item);
            ItemTopMenu item1 = new ItemTopMenu();
            item1.Name = "Đăng kí";
            item1.Link = "/Home/Register";
            temp.Add(item1);
            return temp;
        }
        public List<ItemTopMenu> withSession(string Name,string GroupID)
        {
            List<ItemTopMenu> temp = new List<ItemTopMenu>();
        
            if(GroupID == "ADMIN")
            {
                ItemTopMenu item2 = new ItemTopMenu();
                item2.Name = "Admin Mode";
                item2.Link = "/Admin";
                temp.Add(item2);
            }
            ItemTopMenu item = new ItemTopMenu();
            item.Name = "Đăng xuất";
            item.Link = "/Home/CheckOut";
            temp.Add(item);
            ItemTopMenu item1 = new ItemTopMenu();
            item1.Name = Name;
            item1.Link = "/Home/Index";
            temp.Add(item1);

       
            return temp;
        }
    }
}