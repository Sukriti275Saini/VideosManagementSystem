using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.User
{
    public class DashboardModel : PageModel
    {
        public Users getuser { get; set; }

        public IEnumerable<UsersVideoRecord> userRecords { get; set; }

        public IEnumerable<Blogs> getallblogs { get; set; }

        public IEnumerable<Videos> getvideos { get; set; }

        public string UserName { get; set; } 

        private readonly IUserData userdata;
        private readonly IBlogData blogData;
        private readonly IUVRecordData vidTaken;
        private readonly IVideoData videoData;

        public DashboardModel(IUserData userdata, IBlogData blogData, IUVRecordData vidTaken, IVideoData videoData)
        {
            this.userdata = userdata;
            this.blogData = blogData;
            this.vidTaken = vidTaken;
            this.videoData = videoData;
        }

        public IActionResult OnGet(string urlname)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) &&
                HttpContext.Session.GetString("username") != urlname)
            {
                return RedirectToPage("/Index");
            }
            UserName = urlname;
            getuser = userdata.GetByUserName(urlname);
            userRecords = vidTaken.GetRecordsByUsername(urlname);
            getallblogs = blogData.GetBlogByUsername(UserName);
            return Page();
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

    }
}