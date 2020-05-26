using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.User
{
    public class DeleteBlogModel : PageModel
    {
        private readonly IBlogData blogdata;

        public DeleteBlogModel(IBlogData blogdata)
        {
            this.blogdata = blogdata;
        }

        public Blogs deleteblog { get; set; }

        public IActionResult OnGet(int blogId)
        {
            deleteblog = blogdata.GetBlogById(blogId);
            if (deleteblog == null)
            {
                return RedirectToPage("./Dashboard", new { urlname = HttpContext.Session.GetString("username") });
            }
            return Page();
        }

        public IActionResult OnPost(int blogId)
        {
            var confirmdelete = blogdata.DeleteBlog(blogId);
            if (confirmdelete != true)
            {
                return Page();
            }
            blogdata.Commit();
            var us = HttpContext.Session.GetString("username");
            return RedirectToPage("Dashboard", new { urlname = us });
        }
    }
}