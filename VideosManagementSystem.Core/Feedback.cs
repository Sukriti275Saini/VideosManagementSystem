using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideosManagementSystem.Core
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string Message { get; set; }

        public string Suggestions { get; set; }
    }
}
