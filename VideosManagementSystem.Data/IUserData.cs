using System;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public interface IUserData
    {
        public IEnumerable<Users> GetAllUsers();

        public IEnumerable<Users> GetUserByName(string username);

        Users GetByUserName(string username);

        string Add(Users newUser);

        string LoginUser(string username, string Password);

        string Delete(string username);

        public int Commit();
    }
}
