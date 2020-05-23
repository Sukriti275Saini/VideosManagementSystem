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

        public bool AddBlog(Blogs userBlog);

        public int Commit();
    }
}
