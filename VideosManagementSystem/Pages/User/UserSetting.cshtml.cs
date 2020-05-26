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
    public class UserSettingModel : PageModel
    {
        private readonly IUserData userData;

        public UserSettingModel(IUserData userData)
        {
            this.userData = userData;
        }

        public Users userDetails { get; set; }

        public void OnGet(string username)
        {
            userDetails = userData.GetByUserName(username);
        }
    }
}