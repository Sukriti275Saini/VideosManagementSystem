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

        [Required(ErrorMessage = "Enter a video name")]
        [StringLength(50)]
        public string VideoName { get; set; }

        [Required(ErrorMessage = "Enter the release year")]
        [Range(1900, 2020, ErrorMessage = "Videos from 1900 to 2020")]
        public int YearOfRelease { get; set; }

        [Required(ErrorMessage = "Enter the languages in which the video is available")]
        [StringLength(40, ErrorMessage = "Minimum length required is 3", MinimumLength = 3)]
        public string Language { get; set; }

        [Required(ErrorMessage = "Enter the name of the director")]
        [StringLength(30, ErrorMessage = "Minimum length required is 3", MinimumLength = 3)]
        public string Director { get; set; }

        [Required(ErrorMessage = "Enter the name of the actor")]
        [StringLength(30, ErrorMessage = "Minimum length required is 3", MinimumLength = 3)]
        public string Actor { get; set; }

        [Required(ErrorMessage = "Enter the description")]
        [StringLength(500, ErrorMessage = "Minimum 10 words", MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter the no of copies available")]
        [Range(2, 30, ErrorMessage = "Add only if minimum 2 copies and maximum 30 are available")]
        public int NoOfCopies { get; set; }

        [Required(ErrorMessage = "Enter the lease amount")]
        [Range(20, 1500)]
        public int LeaseAmount { get; set; }

        public string VideoImage { get; set; }
    }
}
