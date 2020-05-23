using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.Admin.ManageVideos
{
    public class AddVideoModel : PageModel
    {
        private readonly IVideoData addVideo;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AddVideoModel(IVideoData addVideo, IWebHostEnvironment webHostEnvironment)
        {
            this.addVideo = addVideo;
            this.webHostEnvironment = webHostEnvironment;
            VideoDetails = new Videos();
        }

        [BindProperty]
        public Videos VideoDetails { get; set; }

        [BindProperty]
        public IFormFile VidImage { get; set; }

        public string Message { get; set; }


        public IActionResult OnPost(Videos VideoDetails)
        {
            if( VidImage != null)
            {
                VideoDetails.VideoImage = UploadedImage(VidImage);
            }
            if (ModelState.IsValid)
            {
                Message = addVideo.Add(VideoDetails);
                if(Message == "New Video Added")
                {
                    addVideo.Commit();
                    return RedirectToPage("./VideosList");
                }
            }
            return Page();
        }

        private string UploadedImage(IFormFile VidImage)
        {
            string uniqueFileName = null;

            if (VidImage != null)
            {
                var file = Path.Combine(webHostEnvironment.WebRootPath, "Images/movies");
                uniqueFileName = VideoDetails.VideoName + "_" + VidImage.FileName;
                string filePath = Path.Combine(file, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    VidImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}