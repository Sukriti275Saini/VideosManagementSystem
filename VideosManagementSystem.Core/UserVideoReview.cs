using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideosManagementSystem.Core
{
    public class UserVideoReview
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public Videos Videos { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        [Range(1, 10)]
        public string Rating { get; set; }
    }
}
