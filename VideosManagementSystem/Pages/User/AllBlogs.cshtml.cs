using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.User
{
    public class AllBlogsModel : PageModel
    {
        private readonly IBlogData blogData;

        public AllBlogsModel(IBlogData blogData)
        {
            this.blogData = blogData;
        }

        public IEnumerable<Blogs> allblogs { get; set; }

        public void OnGet(string username)
        {
            allblogs = blogData.GetBlogByUsername(username);
        }
    }
}