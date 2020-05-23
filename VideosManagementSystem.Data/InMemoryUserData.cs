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
                      orderby usr.UserName
                      select usr;
            return all;
        }

        IEnumerable<Users> IUserData.GetUserByName(string username)
        {
            var usrname = from usr in db.User
                        where usr.UserName.StartsWith(username) || string.IsNullOrEmpty(username)
                        orderby usr.UserName
                        select usr;
            return usrname;
        }

        public Users GetByUserName(string username)
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

        public string LoginUser(string username, string Password)
        {
            var checkuser = GetByUserName(username);
            if (checkuser != null)
            {
                var result = checkuser.Password.Equals(Password);
                if (!result)
                {
                    return "Incorrect Password";
                }
                return "Successfull";
            }
            return "Username not found";
        }

        public string Delete(string username)
        {
            var deluser = GetByUserName(username);
                if(deluser != null)
            {
                db.User.Remove(deluser);
            }
            return "User Deleted";
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

    }
}
