using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideosManagementSystem.Core
{
    public class Blogs
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public Users Users { get; set; }

        [Required]
        public string BlogTitle { get; set; }

        [Required]
        public string BlogDescription { get; set; }

        public string BlogImage { get; set; }

        [Required]
        public string Blogcontent { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BlogDate { get; set; }

        public int BlogLikes { get; set; }

        public int BlogDislikes { get; set; }
    }
}
