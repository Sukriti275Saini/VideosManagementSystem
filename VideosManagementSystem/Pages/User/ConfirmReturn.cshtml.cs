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
    public class ConfirmReturnModel : PageModel
    {
        private readonly IUVRecordData rd;

        public ConfirmReturnModel(IUVRecordData rd)
        {
            this.rd = rd;
        }

        public UsersVideoRecord confirmvideo { get; set; }

        public IActionResult OnGet(int rId)
        {
            confirmvideo = rd.GetRecordById(rId);
            if (confirmvideo == null)
            {
                return RedirectToPage("./Dashboard", new { urlname = HttpContext.Session.GetString("username") });
            }
            return Page();
        }

        public IActionResult OnPost(int rId)
        {
            var confirmdelete = rd.DeleteVideoRecord(rId);
            if (confirmdelete != true)
            {
                return Page();
            }
            rd.Commit();
            var us = HttpContext.Session.GetString("username");
            return RedirectToPage("Dashboard", new { urlname = us });
        }
    }
}