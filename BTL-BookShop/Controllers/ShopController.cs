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
        public object Covert { get; private set; }

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
        public ActionResult Search(string query, int? page)
        {
           
            if (query == null) query = "";
            if (page == null) page = 1;
            var model = new F_Book().getAll().Where(x => x.Name.Contains(query)).OrderBy(x => x.ID).ToList();
            ViewBag.Title = "q=" + query + "&page=" + page;

            int pageSize = 6;            
            int pageNumber = (page ?? 1);
            
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();            
            return View("Search", model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult timkiemtheocategory(string query,  int? page)
        {
            long? id = Convert.ToInt64(query);
            if(id==null) id = Convert.ToInt64(Request.QueryString["query"]);

            ViewBag.Title = "category=" + id + "&page=" + page;
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

            List<Book> u = new List<Book>();
            foreach (var v in list)
            {
                Book temp = new Book();
                temp.ID = v.ID;
                temp.Name = v.Name;
                temp.Price = v.NumberPage;
                temp.Image = v.Image;
                u.Add(temp);
            }
            ViewBag.Book = list;
            F_Category fctg = new F_Category();
            ViewBag.ListCategory = fctg.getAll();
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View("Search", u.ToPagedList(pageNumber, pageSize));
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