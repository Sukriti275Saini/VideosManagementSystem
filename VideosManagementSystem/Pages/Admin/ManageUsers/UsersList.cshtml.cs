using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.Admin.ManageUsers
{
    public class UsersListModel : PageModel
    {
        private readonly IUserData userData;

        public UsersListModel(IUserData userData)
        {
            this.userData = userData;
        }

        public IEnumerable<Users> allUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchUser { get; set; }

        public void OnGet(string searchUser)
        {
            allUser = userData.GetUserByName(searchUser);
        }
    }
}