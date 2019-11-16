using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BTL_BookShop.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Admin/Author
        public ActionResult Index()
        {
            ViewBag.user = Session["User"] as User;
            IEnumerable<Author> authors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50209/api/");
                //HttpGet
                var responseTask = client.GetAsync("Author");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Author>>();
                    readTask.Wait();
                    authors = readTask.Result;
                }
                else
                {
                    authors = Enumerable.Empty<Author>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(authors);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.user = Session["User"] as User;
            ViewBag.Type = new SelectList(new F_Author().Form());
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author us)
        {
            ViewBag.user = Session["User"] as User;
            //if (ModelState.IsValid)
            //{
            //    var fauthor = new F_Author();
            //    int res = fauthor.Insert(us);
            //    if (res > 0) return RedirectToAction("Index");
            //    else ModelState.AddModelError("Notice", "Them khong thanh cong");

            //}
            using (var client  = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50209/api/Author");
                //http post
                var postTask = client.PostAsJsonAsync<Author>("Author", us);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View("Index");

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            ViewBag.user = Session["User"] as User;
            ViewBag.Type = new SelectList(new F_Author().Form());
            var author = new F_Author().ViewDetail(ID);
            return View(author);

        }
        [HttpPost]
        public ActionResult Update(Author us)
        {
            ViewBag.user = Session["User"] as User;
            if (ModelState.IsValid)
            {
                var fauthor = new F_Author();
                int res = fauthor.Update(us);
                if (res > 0) return RedirectToAction("Index");
                else ModelState.AddModelError("Notice", "Them khong thanh cong");
            }

            return View("Index");

        }
        public ActionResult Delete(long ID)
        {
            ViewBag.user = Session["User"] as User;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50209/api/Author");
                //http delete
                var deleteTask = client.DeleteAsync("Author/" + ID.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
            //var fauthor = new F_Author();
            //long? res = fauthor.Delete(fauthor.FindEntity(ID));
            //if (res > 0) return RedirectToAction("Index");
            //else ModelState.AddModelError("Notice", "Them khong thanh cong");
            //return View("Index");

        }
    }
}