using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_BookShop.Models.Entities;
namespace BTL_BookShop.Models.Function
{
    public class F_User
    {
        private MyDBContext context;
        public F_User()
        {
            context = new MyDBContext();
        }
        public bool Login_Test(string user,string password)
        {
            var result = context.Users.Count(x => x.UserName == user && x.Password == password);
            if (result > 0) return true;
            else return false;
        }
        public User Login(string user_name,string password)
        {
            List<User> ds = new List<User>();
            User user = new User();
            ds = context.Users.Where(x => x.UserName == user_name && x.Password == password).ToList();
            if (Login_Test(user_name, password) == true)
            {

                user = ds[0];
            }
            else
            {

            }
            return user;

        }
        public User getByUserName(string UserName)
        {
            return context.Users.SingleOrDefault(x => x.Name == UserName);
        }
        public IQueryable<User> DS_User
        {
            get { return context.Users; }
        }
        public User FindEntity(long ID)
        {
            User dbEntry = context.Users.Find(ID);
            return dbEntry;
        }
        public long? Insert(User model)
        {
            User dbEntry = context.Users.Find(model.ID);
            if(dbEntry!=null)
            {
                return null;
            }
            context.Users.Add(model);
            context.SaveChanges();
            return model.ID;
        }
        public long? Update(User model)
        {
            User dbEntry = context.Users.Find(model.ID);
            if(dbEntry==null)
            {
                return null;
            }
            dbEntry = model;
            context.SaveChanges();
            return model.ID;
        }
        public long? Delete(long Id)
        {
            User dbEntry = context.Users.Find(Id);
            if(dbEntry==null)
            {
                return null;
            }
            context.Users.Remove(dbEntry);
            context.SaveChanges();
            return Id;
        }

        public List<string> GetListCredential(string userName)
        {
            var user = context.Users.Single(x => x.UserName == userName);
            var data = (from a in context.Credentials
                        join b in context.UserGroups on a.UserGroupID equals b.ID
                        join c in context.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }

    }
}