using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.User
{
    public class WriteBlogModel : PageModel
    {
        private readonly IBlogData blogData;
        private readonly IUserData userData;
        private readonly IWebHostEnvironment hostEnvironment;

        public WriteBlogModel(IBlogData blogData, IUserData userData, IWebHostEnvironment hostEnvironment)
        {
            this.blogData = blogData;
            this.userData = userData;
            this.hostEnvironment = hostEnvironment;
            writeBlog = new Blogs();
        }

        [BindProperty]
        public Blogs writeBlog { get; set; }
        public Users SingleUserData { get; set; }
        [BindProperty]
        public IFormFile BlogPicture { get; set; }
        public IActionResult OnGet()
        {
            var Username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(Username))
            {
                return RedirectToPage("/Index");
            }
            SingleUserData = userData.GetByUserName(Username);
            writeBlog = new Blogs();
            return Page();
        }

        public IActionResult OnPost()
        {
            var Username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(Username))
            {
                return RedirectToPage("/Index");
            }
            SingleUserData = userData.GetByUserName(Username);
            writeBlog.Users = SingleUserData;
;
            if (BlogPicture != null)
            {
                writeBlog.BlogImage = UploadedPicture(BlogPicture,SingleUserData.UserName);
            }
            
                var newBlog = new Blogs(){
                    Users = writeBlog.Users,
                    BlogTitle = writeBlog.BlogTitle,
                    BlogDescription = writeBlog.BlogDescription,
                    Blogcontent = writeBlog.Blogcontent,
                    BlogDate = DateTime.Now.Date,
                    BlogImage = writeBlog.BlogImage
                };

                bool res = blogData.AddBlog(newBlog);
                if (res)
                {
                    blogData.Commit();
                    return RedirectToPage("/User/Dashboard", new { urlname = Username });
                }
                return Page();
        }

        private string UploadedPicture(IFormFile BlogPicture, string username)
        {
            string uniqueFileName = null;

            if (this.BlogPicture != null)
            {
                var file = Path.Combine(hostEnvironment.WebRootPath, "Images/blogs/");
                uniqueFileName = username + "_" + BlogPicture.FileName;
                string filePath = Path.Combine(file, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BlogPicture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}