using System;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public interface IBlogData
    {
        public IEnumerable<Blogs> GetAllBlogs();

        public IEnumerable<Blogs> GetBlogByUsername(string username);

        public Blogs GetBlogByUser(string username);

        public Blogs GetBlogById(int BlogId);

        public bool AddBlog(Blogs userBlog);

        public bool DeleteBlog(int BlogId);

        public int Commit();
    }
}
