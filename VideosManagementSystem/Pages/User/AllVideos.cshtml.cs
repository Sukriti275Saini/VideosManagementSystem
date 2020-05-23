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
    public class AllVideosModel : PageModel
    {
        private readonly IVideoData videoData;
        public IEnumerable<Videos> AllVideo { get; set; }
        
        public AllVideosModel(IVideoData videoData)
        {
            this.videoData = videoData;
        }

        [BindProperty(SupportsGet = true)]
        public string searchVideo { get; set; }

        public void OnGet(string searchVideo)
        {
            AllVideo = videoData.GetByVideoName(searchVideo);
        }
    }
}