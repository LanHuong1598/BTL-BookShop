using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using BTL_BookShop.Models;
using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Function;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
       
        // thêm vào giỏ hàng 1 sản phẩm có id = id của sản phẩm
        [HttpPost]
        public ActionResult ThemVaoGioHang(int id, int soLuong)
        {

            MyDBContext db = new MyDBContext();
            var p = db.Books.SingleOrDefault(s => s.ID.Equals(id));

            if (p != null)
            {
                Cart objCart = (Cart)Session["Cart"];
                if (objCart == null)
                {
                    objCart = new Cart();
                }
                CartItem temp = new CartItem()
                {

                    ItemID = p.ID,
                    Quantity = soLuong,
                    DateAdded = System.DateTime.Today,
                    CustomerID = 1
                };
                objCart.AddToCart(temp);
                Session["Cart"] = objCart;

            }
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject("Thêm thành công", Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet); ;

        }
        // cập nhật giỏ hàng theo loại sản phẩm và số lượng

        public ActionResult CapNhatSoLuong(int id, string soLuong)
        {
           
            int sl;
            if (Int32.TryParse(soLuong, out sl) == false) sl = 1;
            Cart objCart = (Cart)Session["Cart"];
            if (objCart != null)
            {
                objCart.CapNhatSoLuong(id, sl);
                Session["Cart"] = objCart;
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject("Cập nhật thành công", Formatting.Indented, jss);
                return this.Json(result, JsonRequestBehavior.AllowGet); ;

            }
            return RedirectToAction("index");
        }
        // giỏ hàng mặc định, nếu session = null thì hiện không có hàng trong giỏ, nếu có thì trả lại list các sản phẩm
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Giỏ hàng";
            GioHangViewModel model = new GioHangViewModel();
            model.Cart = (Cart)Session["Cart"];
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            return View(model);
        }
        public ActionResult Payment()
        {
            ViewBag.Title = "Giỏ hàng";
            GioHangViewModel model = new GioHangViewModel();
            model.Cart = (Cart)Session["Cart"];
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            return View(model);
        }
        [HttpPost]

        public ActionResult Checkout(string shipName, string mobile, string address, string email)
        {
           

            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAdress = address;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;
           
            try
                {
                    var id = new F_Order().Insert(order);

                    var cart = (Cart)Session["Cart"];

                    var detailDao = new F_Order_Detail();
                    decimal total = 0;
                    foreach (var item in cart.ListItem)
                    {
                        var orderDetail = new Order_Detail();
                        orderDetail.BookID = item.ItemID;
                        Book book = new F_Book().FindBook(item.ItemID);
                        orderDetail.Price = book.PromotionPrice ;
                        orderDetail.Quantity = item.Quantity;  
                        orderDetail.OrderID = Convert.ToInt32(id);
                        orderDetail.Quantity = item.Quantity;
                        detailDao.Insert(orderDetail);
                        total += Convert.ToInt32(orderDetail.Price) * Convert.ToInt32(orderDetail.Quantity);
                    }

                    order.TotalPrice = total;
                    var id1 = new F_Order().Update(order);
                    Cart objCart = (Cart)Session["Cart"];
                    objCart.GioHangRong();
                Session["Cart"] = objCart;

            }
            catch (Exception ex)
                {
                    //ghi log
                    return RedirectToAction("/Loi");
                }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NhapThongTin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {
            Cart objCart = (Cart)Session["Cart"];
            if (objCart != null)
            {
                objCart.XoaSanPham(id);
                Session["Cart"] = objCart;
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject("Xóa thành công", Formatting.Indented, jss);
                return this.Json(result, JsonRequestBehavior.AllowGet); ;
            }
            return RedirectToAction("index");
        }
    }
}