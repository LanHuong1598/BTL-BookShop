using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_BookShop.Models.Entities;
using BTL_BookShop;

namespace BTL_BookShop.Models.Function
{
    public class F_Author
    {
        private MyDBContext context;

        public List<Author> getAll()
        {
            List<Author> ans = context.Authors.ToList();
            return ans;
        }

        public F_Author()
        {
            context = new MyDBContext();
        }

        public IQueryable<Author> DSDM
        {
            get { return context.Authors; }
        }

        public Author FindEntity(long ma)
        {
            Author dbE = context.Authors.Find(ma);
            return dbE;
        }

        public int Insert(Author us)
        {
            context.Authors.Add(new Author { Name = us.Name, Description = us.Description, DateOfBirth = us.DateOfBirth, Image = us.Image, Type = us.Type });
            int res = context.SaveChanges();
            return res;
        }
        public int Update(Author us)
        {
            Author author = context.Authors.Find(us.ID);
            author.Name = us.Name;
            author.Description = us.Description;
            author.DateOfBirth = us.DateOfBirth;
            author.Image = us.Image;
            author.Type = us.Type;
            int res = context.SaveChanges();
            return res;
        }
        public long? Delete(Author model)
        {
            Author temp = context.Authors.Find(model.ID);
            if (temp == null)
            {
                return null;
            }
            else
            {
                context.Authors.Remove(model);
                context.SaveChanges();
                return model.ID;
            }
        }
        public List<string> Form()
        {
            var listForm = new List<string>();
            listForm.Add("Trong nước");
            listForm.Add("Nước ngoài");

            return listForm;
        }
        public Author ViewDetail(int id)
        {
            Author res = context.Authors.Find(id);
            return res;
        }
    }
}