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

        public IEnumerable<UsersVideoRecord> GetAllRecords()
        {
            var allrecords = from rec in db.Records.Include("Videos").Include("Users")
                             orderby rec.Users.UserName
                             select rec;
            return allrecords;
        }

        public UsersVideoRecord GetRecordById(int recordId)
        {
            var query = from r in db.Records.Include("Video").Include("User") 
                        where r.RecordId.Equals(recordId) 
                        select r;
            return query.FirstOrDefault();
        }

        public IEnumerable<UsersVideoRecord> GetRecordsByUsername(string username)
        {
            var usrname = from usr in db.Records.Include("Users")
                          where usr.Users.UserName.StartsWith(username) || string.IsNullOrEmpty(username)
                          orderby usr.IssueDate
                          select usr;
            return usrname;
        }
        
        public int Commit()
        {
            return db.SaveChanges();
        }

        public bool AddVideoRecord(UsersVideoRecord newVideoRecord)
        {
            db.Records.Add(newVideoRecord);
            return true;
        }

        public bool DeleteVideoRecord(int recordId)
        {
            db.Records.Remove(GetRecordById(recordId));
            return true;
        }
    }
}
