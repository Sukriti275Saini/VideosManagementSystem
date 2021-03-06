﻿using System;
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
    public class VideoDetailsModel : PageModel
    {
        private readonly IVideoData videoData;
        private readonly IUserData userData;
        private readonly IUVRecordData videoRecordData;

        public VideoDetailsModel(IVideoData videoData, IUserData userData, IUVRecordData videoRecordData)
        {
            this.videoData = videoData;
            this.userData = userData;
            this.videoRecordData = videoRecordData;
        }

        public Videos eachVideo { get; set; }
        
        public void OnGet(int vId)
        {
            eachVideo = videoData.GetVideosById(vId);
        }

        public IActionResult OnPost(int vId)
        {
            var Username = HttpContext.Session.GetString("username");
            //var Username = "Sukriti275Saini";
            if (string.IsNullOrEmpty(Username))
            {
                return RedirectToPage("/Index");
            }
            var newVidRecord = new UsersVideoRecord()
            {
                Users = userData.GetByUserName(Username),
                Videos = videoData.GetVideosById(vId),
                IssueDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14),
                DueAmount = 0
            };  
            bool res = videoRecordData.AddVideoRecord(newVidRecord);
            if (res)
            {
                videoRecordData.Commit();
                return RedirectToPage("Dashboard", new { urlname = Username });
            }
            return Page();
        }
    }
}