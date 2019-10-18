﻿using System;
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
    }
}