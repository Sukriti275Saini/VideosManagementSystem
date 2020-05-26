using System;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public interface IUVRecordData
    {
        public IEnumerable<UsersVideoRecord> GetAllRecords();

        public IEnumerable<UsersVideoRecord> GetRecordsByUsername(string username);

        public UsersVideoRecord GetRecordById(int recordId);

        public UsersVideoRecord GetByUsername(string username);

        bool AddVideoRecord(UsersVideoRecord newVideoRecord);

        bool DeleteVideoRecord(int recordId);

        int Commit();
    }
}
