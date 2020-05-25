using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.User
{
    public class DashboardModel : PageModel
    {
        public Users getuser { get; set; }

        public IEnumerable<Blogs> getallblogs { get; set; }

        private readonly IUserData userdata;
        private readonly IBlogData blogData;
        private readonly IUVRecordData vidTaken;

        public DashboardModel(IUserData userdata, IBlogData blogData, IUVRecordData vidTaken)
        {
            this.userdata = userdata;
            this.blogData = blogData;
            this.vidTaken = vidTaken;
        }

        public void OnGet(string urlname)
        {
            var Username = HttpContext.Session.GetString("username");
            getuser = userdata.GetByUserName(urlname);
            getallblogs = blogData.GetBlogByUsername(Username);
        }
    }
}