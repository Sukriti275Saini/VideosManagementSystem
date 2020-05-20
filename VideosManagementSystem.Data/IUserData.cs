using System;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public interface IUserData
    {
        public IEnumerable<Users> GetAllUsers();

        Users GetUserByName(string username);

        string Add(Users newUser);

        public int Commit();
    }
}
