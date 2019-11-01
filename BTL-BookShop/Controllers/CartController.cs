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
        public ActionResult XoaSanPham(int id)
        {
            Cart objCart = (Cart)Session["Cart"];
            if (objCart != null)
            {
                objCart.XoaSanPham(id);
                Session["Cart"] = objCart;
            }
            return RedirectToAction("index");
        }
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

        public ActionResult CapNhatSoLuong(string maSp, int soLuong)
        {
            int id = Convert.ToInt32(maSp.Substring(7, maSp.Length - 7));
            Cart objCart = (Cart)Session["Cart"];
            if (objCart != null)
            {
                objCart.CapNhatSoLuong(id, soLuong);
                Session["Cart"] = objCart; 
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
        [HttpPost]

        public ActionResult NhapThongTin()
        {
            return View();
        }
    }
}