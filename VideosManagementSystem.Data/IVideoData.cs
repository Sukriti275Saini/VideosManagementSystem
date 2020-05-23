using System;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public interface IVideoData
    {
        public IEnumerable<Videos> GetAllVideos();

        Videos GetVideosById(int vidId);

        public IEnumerable<Videos> GetByVideoName(string vidname);

        Videos GetVideoByName(string vidname);

        string Add(Videos newVideo);

        Videos Delete(int vidId);

        public int Commit();
    }
}
