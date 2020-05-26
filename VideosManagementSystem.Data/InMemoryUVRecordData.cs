using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public class InMemoryUVRecordData : IUVRecordData
    {
        private readonly VMSDbContext db;
        private readonly IVideoData vd;

        public InMemoryUVRecordData(VMSDbContext db, IVideoData vd)
        {
            this.db = db;
            this.vd = vd;
        }

        public IEnumerable<UsersVideoRecord> GetAllRecords()
        {
            var allrecords = from rec in db.Records.Include("Videos").Include("Users")
                             orderby rec.Users.UserName
                             select rec;
            return allrecords;
        }

        public UsersVideoRecord GetRecordById(int recordId)
        {
            var query = from r in db.Records.Include("Videos").Include("Users") 
                        where r.RecordId.Equals(recordId) 
                        select r;
            return query.FirstOrDefault();
        }

        public IEnumerable<UsersVideoRecord> GetRecordsByUsername(string username)
        {
            var usrname = from usr in db.Records.Include("Videos")
                          where usr.Users.UserName.Equals(username)
                          orderby usr.IssueDate
                          select usr;
            return usrname;
        }

        public UsersVideoRecord GetByUsername(string username)
        {
            return db.Records.Find(username);
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public bool AddVideoRecord(UsersVideoRecord newVideoRecord)
        {
            db.Records.Add(newVideoRecord);
            var video = vd.GetVideosById(newVideoRecord.Videos.VideoId);
            video.NoOfCopies = video.NoOfCopies - 1;
            db.Entry(video).Property("NoOfCopies").IsModified = true;
            return true;
        }

        public bool DeleteVideoRecord(int recordId)
        {
            db.Records.Remove(GetRecordById(recordId));
            var record = GetRecordById(recordId);
            var video = vd.GetVideosById(record.Videos.VideoId);
            video.NoOfCopies = video.NoOfCopies + 1;
            db.Entry(video).Property("NoOfCopies").IsModified = true;
            return true;
        }

    }
}
