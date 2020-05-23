using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public class InMemoryVideoData : IVideoData
    {
        private readonly VMSDbContext db;

        public InMemoryVideoData(VMSDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Videos> GetAllVideos()
        {
            var allvideos = from vids in db.Video
                            orderby vids.VideoName
                            select vids;
            return allvideos;
        }

        public Videos GetVideosById(int vidId)
        {
            return db.Video.Find(vidId);
        }

        public IEnumerable<Videos> GetByVideoName(string vidname)
        {
            var videoname = from vid in db.Video
                          where vid.VideoName.StartsWith(vidname) || string.IsNullOrEmpty(vidname)
                          orderby vid.VideoName
                          select vid;
            return videoname;
        }

        public Videos GetVideoByName(string vidname)
        {
            return db.Video.Find(vidname);
        }
        public string Add(Videos newVideo)
        {
            var checkvidname = from vid in db.Video
                               where vid.VideoName.Equals(newVideo.VideoImage)
                               select vid;
            if (checkvidname.Count()> 0)
            {
                return "Video with this name already exists";
            }
            db.Add(newVideo);
            return "New Video Added";
        }

        public Videos Delete(int vidId)
        {
            var deletevid = GetVideosById(vidId);
            if(deletevid != null)
            {
                db.Video.Remove(deletevid);
            }
            return deletevid;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

    }
}
