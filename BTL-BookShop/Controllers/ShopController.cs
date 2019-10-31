using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Function;
using BTL_BookShop.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Search(string txt)
        {
            var model = new F_Book().getAll().Where(x => x.Name.Contains(txt)).ToList();
            ViewBag.Book = model;
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
                            ID = book.ID,
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
    }
}