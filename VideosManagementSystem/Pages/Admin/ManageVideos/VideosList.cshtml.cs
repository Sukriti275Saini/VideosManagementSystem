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
    public class VideosListModel : PageModel
    {
        private readonly IVideoData videoData;

        public VideosListModel(IVideoData videoData)
        {
            this.videoData = videoData;
        }

        public IEnumerable<Videos> allVideos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchVideo { get; set; }

        public void OnGet(string searchVideo)
        {
            allVideos = videoData.GetByVideoName(searchVideo);
        }
    }
}