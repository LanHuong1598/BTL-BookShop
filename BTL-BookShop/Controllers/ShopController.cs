using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Function;
using BTL_BookShop.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace BTL_BookShop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Product(long id)
        {
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            var model = new F_Book().FindEntity(id);
            ViewBag.Book = model;
            return View();
        }
        public ActionResult Search(string txt, int? page)
        {
            if (txt == null) txt = "";
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var model = new F_Book().getAll().Where(x => x.Name.Contains(txt)).OrderBy(x => x.ID).ToList();

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            

            ViewBag.Book = model.ToPagedList(pageNumber, pageSize);
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            
            return View();
        }
        public ActionResult timkiemtheocategory(long id)
        {
            var listBook = new F_CategoryBook().getAll().Where(x => x.IDCategory == id).ToList();
            var dsBook = new F_Book().getAll();
            var list = (from book in listBook
                        join book1 in dsBook on book.IDBook equals book1.ID
                        select new Book
                        {
                            ID = book1.ID,
                            Name = book1.Name,
                            Image = book1.Image,
                            Price = book1.Price

                        });
            ViewBag.Book = list;
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();

            return View("Search");
        }

        public ActionResult timkiemtheoNXB(long id)
        {

            var dsBook = new F_Book().getAll().Where(x => x.Publisher == id);
            ViewBag.Book = dsBook;
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            return View("Search");
        }
        public ActionResult timkiemtheotacgia(long id)
        {

            var dsBook = new F_Book().getAll().Where(x => x.Author == id);
            ViewBag.Book = dsBook;
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            return View("Search");
        }
        public ActionResult timkiemtheogia(string begin, string end)
        {
            int u = Convert.ToInt32(begin);
            int v = Convert.ToInt32(end);
            var dsBook = new F_Book().getAll().Where(x => x.Price >= u && x.Price <= v);
            ViewBag.Book = dsBook;
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            return View("Search");
        }
    }
}