using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.Admin.ManageVideos
{
    public class DeleteVideoModel : PageModel
    {
        private readonly IVideoData deleteVideo;

        public DeleteVideoModel(IVideoData deleteVideo)
        {
            this.deleteVideo = deleteVideo;
        }

        public Videos confirmvideo { get; set; }

        public void OnGet(int vidId)
        {
            confirmvideo = deleteVideo.GetVideosById(vidId);
            if(confirmvideo == null)
            {
                RedirectToPage("./VideosList");
            }
        }

        public IActionResult OnPost(int vidId)
        {
            var confirmdelete = deleteVideo.GetVideosById(vidId);
            if(confirmdelete == null)
            {
                return Page();
            }
            deleteVideo.Delete(vidId);
            deleteVideo.Commit();
            return RedirectToPage("./VideosList");
        }
    }
}