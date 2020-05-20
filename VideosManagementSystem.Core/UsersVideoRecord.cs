using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideosManagementSystem.Core
{
    public class UsersVideoRecord
    {
        [Key]
        public int RecordId { get; set; }

        public Users UserName { get; set; }

        public Videos VideoName { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int DueAmount { get; set; }
    }
}
