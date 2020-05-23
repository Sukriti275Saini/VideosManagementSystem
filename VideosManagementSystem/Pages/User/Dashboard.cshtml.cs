using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private readonly IUserData userdata;

        public DashboardModel(IUserData userdata)
        {
            this.userdata = userdata;
        }

        public void OnGet(string urlname)
        {
            getuser = userdata.GetByUserName(urlname);
        }
    }
}