using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.User
{
    public class NewUserModel : PageModel
    {
        private readonly IUserData userSignup;
        private readonly IWebHostEnvironment hostEnvironment;

        [BindProperty]
        public Users UserDetails { get; set; }

        [BindProperty]
        public IFormFile UploadPicture { get; set; }

        public string Message { get; set; }

        public NewUserModel(IUserData userSignup, IWebHostEnvironment hostEnvironment)
        {
            this.userSignup = userSignup;
            this.hostEnvironment = hostEnvironment;
            UserDetails = new Users();
        }

        public async Task<IActionResult> OnPost(IFormFile UploadPicture)
        {
            var file = Path.Combine(hostEnvironment.WebRootPath, "Images", UserDetails.UserName + "_" + UploadPicture.FileName);
            using (var filestream = new FileStream(file, FileMode.Create))
            {
                await UploadPicture.CopyToAsync(filestream);
            }
            UserDetails.ProfilePicture = UserDetails.UserName + "_" + UploadPicture.FileName;

            if (ModelState.IsValid)
            {
                Message = userSignup.Add(UserDetails);
                if (Message == "Added")
                {
                    userSignup.Commit();
                    HttpContext.Session.SetString("username", UserDetails.UserName);
                    return RedirectToPage("/User/Dashboard", new { user = UserDetails.UserName });
                }
            }
            return Page();
        }


        /*public async Task OnPostAsync()
        {
            var file = Path.Combine(hostEnvironment.ContentRootPath, "uploads", UploadPicture.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await UploadPicture.CopyToAsync(fileStream);
            }
        }*/

    }
}