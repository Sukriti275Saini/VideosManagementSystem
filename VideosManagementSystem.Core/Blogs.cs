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

        public Users UserName { get; set; }

        public string BlogTitle { get; set; }

        public string BlogDescription { get; set; }

        public int BlogLikes { get; set; }

        public int BlogDislikes { get; set; }
    }
}
