using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserData usrlogindata;

        public IndexModel(ILogger<IndexModel> logger, IUserData usrlogindata)
        {
            _logger = logger;
            this.usrlogindata = usrlogindata;
            LoginDetails = new Login();
        }


        [BindProperty]
        public Login LoginDetails { get; set; }

        public string Message { get; set; }

        public ILogger<IndexModel> Logger => _logger;

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = usrlogindata.LoginUser(LoginDetails.UserName, LoginDetails.Password);
                if (Message == "Successfull")
                {
                    HttpContext.Session.SetString("username", LoginDetails.UserName);
                    return RedirectToPage("User/Dashboard", new { urlname = LoginDetails.UserName });
                }
            }
            return Page();
        }
    }
}
