using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.User
{
    public class DashboardModel : PageModel
    {
        private readonly IUserData usercontent;

        public DashboardModel(IUserData usercontent)
        {
            this.usercontent = usercontent;
        }

        public void OnGet()
        {
        }
    }
}