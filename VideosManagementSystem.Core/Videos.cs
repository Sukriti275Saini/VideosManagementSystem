using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideosManagementSystem.Core
{
    public class Videos
    {
        [Key]
        public int VideoId { get; set; }

        [Required]
        public string VideoName { get; set; }

        public int YearOfRelease { get; set; }

        public string Language { get; set; }

        public string Director { get; set; }

        public string Actor { get; set; }

        public string Description { get; set; }

        public int NoOfCopies { get; set; }

        public int LeaseAmount { get; set; }
    }
}
