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
    public class DeleteUserModel : PageModel
    {
        private readonly IUserData deleteUser;

        public DeleteUserModel(IUserData deleteUser)
        {
            this.deleteUser = deleteUser;
        }

        public Users confirmuser { get; set; }

        public void OnGet(string username)
        {
            confirmuser = deleteUser.GetByUserName(username);
        }

        public IActionResult OnPost(string username)
        {
            var confirmdelete = deleteUser.Delete(username);
            deleteUser.Commit();
            return RedirectToPage("./UsersList");
        }
    }
}