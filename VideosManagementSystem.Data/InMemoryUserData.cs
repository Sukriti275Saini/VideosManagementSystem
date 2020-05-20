using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public class InMemoryUserData : IUserData
    {
        private readonly VMSDbContext db;

        public InMemoryUserData(VMSDbContext db)
        {
            this.db = db;
        }


        public IEnumerable<Users> GetAllUsers()
        {
            var all = from usr in db.User
                      orderby usr.FullName
                      select usr;
            return all;
        }

        public Users GetUserByName(string username)
        {
            return db.User.Find(username);
        }

        public string Add(Users newUser)
        {
            var checkusername = from usr in db.User
                                where usr.UserName.Equals(newUser.UserName)
                                select usr;
            if (checkusername.Count() > 0)
            {
                return "User Name Already Exists";
            }
            db.Add(newUser);
            return "Added";
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
