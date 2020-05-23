using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IActionResult OnPost(Users UserDetails)
        {
            if (UploadPicture != null)
            {
                UserDetails.ProfilePicture = UploadedProPicture(UploadPicture);
            }

            if (ModelState.IsValid)
            {
                Message = userSignup.Add(UserDetails);
                if (Message == "Added")
                {
                    userSignup.Commit();
                    HttpContext.Session.SetString("username", UserDetails.UserName);
                    return RedirectToPage("Dashboard", new { urlname = UserDetails.UserName });
                }
            }
            return Page();
        }

       
        private string UploadedProPicture(IFormFile UploadPicture)
        {
            string uniqueFileName = null;

            if (UploadPicture != null)
            {
                var file = Path.Combine(hostEnvironment.WebRootPath, "Images/users");
                uniqueFileName = UserDetails.UserName + "_" + UploadPicture.FileName;
                string filePath = Path.Combine(file, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    UploadPicture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        /*public async Task<IActionResult> OnPost(Users UserDetails)
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
                    return RedirectToPage("/Index");
                    //HttpContext.Session.SetString("username", UserDetails.UserName);
                    //return RedirectToPage("/User/Dashboard", new { user = UserDetails.UserName });
                }
            }
            return Page();
        }*/

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