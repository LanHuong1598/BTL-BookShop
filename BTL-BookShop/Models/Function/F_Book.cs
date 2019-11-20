using BTL_BookShop.Areas.Admin.Models;
using BTL_BookShop.Models.Entities;
using BTL_BookShop.Models.ViewTable;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Models.Function
{
    public class F_Book
    {
        MyDBContext context = null;
        public F_Book()
        {
            context = new MyDBContext();
        }
        public IQueryable<Book> ListBooks
        {
            get { return context.Books; }
        }
        public List<Book> getAll()
        {
            List<Book> ans = context.Books.ToList();
            return ans;
        }
        public Book FindBook(long ma)
        {
            Book temp = context.Books.Find(ma);
            return temp;
        }
        public long? Insert(Book model)
        {
            Book temp = context.Books.Find(model.ID);
            if (temp == null)
            {
                context.Books.Add(model);
                context.SaveChanges();
                return model.ID;

            }
            else
            {
                return null;
            }
        }

        public Book FindEntity(long ma)
        {
            Book dbE = context.Books.Find(ma);
            return dbE;
        }

        public long? Update(Book model)
        {
            Book temp = context.Books.Find(model.ID);
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
        public long? Delete(Book model)
        {
            Book temp = context.Books.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Books.Remove(model);
                context.SaveChanges();
                return model.ID;
            }
        }
        // Lay toan bo sach
        public List<BookView> _ListAll()
        {
            return (from b in context.Books
                    join a in context.Authors on b.Author equals a.ID
                    join p in context.Publishers on b.Publisher equals p.ID
                    join r in context.Publishers on b.Released equals r.ID
                    join e in context.CategoryBooks on b.ID equals e.IDBook
                    select new BookView()
                    {
                        ID = b.ID,
                        Code = b.Code,
                        Name = b.Name,
                        Author = a.Name,
                        AuthorID = b.Author,
                        Publisher = p.Name,
                        PublisherID = b.Publisher,
                        Released = r.Name,
                        ReleasedID = b.Released,
                        NumberPage = b.NumberPage,
                        Weight = b.Weight,
                        Form = b.Form,
                        PublishDate = b.PublishDate,
                        Buys = b.Buys,
                        Price = b.Price,
                        PromotionPrice = b.PromotionPrice,
                        CategoryID = e.IDCategory,
                        ViewCount = b.ViewCount,
                        Inventory = b.Inventory,
                        Image = b.Image,
                        Status = b.Status,
                        Description = b.Description
                    }).ToList();
        }
        public List<BookView> _ListSomeBook(int number)
        {
            return (from b in context.Books
                    join a in context.Authors on b.Author equals a.ID
                    join p in context.Publishers on b.Publisher equals p.ID
                    join r in context.Publishers on b.Released equals r.ID
                    join e in context.CategoryBooks on b.ID equals e.IDBook
                    select new BookView()
                    {
                        ID = b.ID,
                        Code = b.Code,
                        Name = b.Name,
                        Author = a.Name,
                        AuthorID = b.Author,
                        Publisher = p.Name,
                        PublisherID = b.Publisher,
                        Released = r.Name,
                        ReleasedID = b.Released,
                        NumberPage = b.NumberPage,
                        Weight = b.Weight,
                        Form = b.Form,
                        PublishDate = b.PublishDate,
                        Buys = b.Buys,
                        Price = b.Price,
                        PromotionPrice = b.PromotionPrice,
                        CategoryID = e.IDCategory,
                        ViewCount = b.ViewCount,
                        Inventory = b.Inventory,
                        Image = b.Image,
                        Status = b.Status,
                        Description = b.Description
                    }).Take(number).ToList();
        }
        public BookView TakeBook(long id)
        {
            var book = (from b in context.Books
                        join a in context.Authors on b.Author equals a.ID
                        join p in context.Publishers on b.Publisher equals p.ID
                        join r in context.Publishers on b.Released equals r.ID
                        join e in context.CategoryBooks on b.ID equals e.IDBook
                        where (b.ID == id)
                        select new BookView()
                        {
                            ID = b.ID,
                            Code = b.Code,
                            Name = b.Name,
                            Author = a.Name,
                            AuthorID = b.Author,
                            Publisher = p.Name,
                            PublisherID = b.Publisher,
                            Released = r.Name,
                            ReleasedID = b.Released,
                            NumberPage = b.NumberPage,
                            Weight = b.Weight,
                            Form = b.Form,
                            PublishDate = b.PublishDate,
                            Buys = b.Buys,
                            Price = b.Price,
                            PromotionPrice = b.PromotionPrice,
                            CategoryID = e.IDCategory,
                            ViewCount = b.ViewCount,
                            Inventory = b.Inventory,
                            Image = b.Image,
                            Status = b.Status,
                            Description = b.Description
                        }).Single();
            return book;
        }
        public IEnumerable<BookModel> ListAllByTag(string searchString, int page, int pageSize)
        {

            var news = (from a in context.Books
                        join b in (from a1 in context.CategoryBooks
                                   join a2 in context.Categories on a1.IDCategory equals a2.ID
                                   select new
                                   {
                                       ID = a2.ID,
                                       Name = a2.Name,

                                   })
                        on a.ID equals b.ID into cates
                        from y1 in cates.DefaultIfEmpty()
                        join c in context.Authors on a.Author equals c.ID into authors
                        from y2 in authors.DefaultIfEmpty()
                        join d in context.Publishers on a.Publisher equals d.ID into pubs
                        from y3 in pubs.DefaultIfEmpty()
                        join f in context.Publishers on a.Released equals f.ID into rels
                        from y4 in rels.DefaultIfEmpty()
                        select new BookModel()
                        {
                            Book = a,
                            NameType = y1.Name,
                            NameAuthor = y2.Name,
                            NamePublisher = y3.Name,
                            NameReleased = y4.Name
                        });
            if (!string.IsNullOrEmpty(searchString))
            {
                news = news.Where(x => x.Book.Name.Contains(searchString) || x.NameAuthor.Contains(searchString) || x.NamePublisher.Contains(searchString) || x.NameReleased.Contains(searchString));

            }
            return news.OrderByDescending(x => x.Book.PublishDate).ToPagedList(page, pageSize);
        }
        public bool changeStatus(int id)
        {
            var book = context.Books.Find(id);
            book.Status = !book.Status;
            context.SaveChanges();
            return (bool)!book.Status;
        }
    }
}