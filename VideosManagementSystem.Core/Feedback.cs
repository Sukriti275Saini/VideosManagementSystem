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

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string AppReview { get; set; }

        [Required]
        public string Suggestions { get; set; }
    }
}
