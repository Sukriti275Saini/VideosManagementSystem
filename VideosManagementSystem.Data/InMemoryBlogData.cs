using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public class InMemoryBlogData : IBlogData
    {
        private readonly VMSDbContext db;

        public InMemoryBlogData(VMSDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Blogs> GetAllBlogs()
        {
            var allb = from b in db.Blog.Include("Users")
                       orderby b.BlogDate
                       select b;
            return allb;
        }

        public IEnumerable<Blogs> GetBlogByUsername(string username)
        {

            var usrname = from usr in db.Blog.Include("Users")
                          where usr.Users.UserName.StartsWith(username) || string.IsNullOrEmpty(username)
                          orderby usr.BlogDate
                          select usr;
            return usrname;
        }

        public bool AddBlog(Blogs userBlog)
        {
            db.Blog.Add(userBlog);
            return true;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

    }
}
