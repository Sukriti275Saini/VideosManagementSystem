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

        [Required]
        public Users Users { get; set; }

        [Required]
        public Videos Videos { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public int DueAmount { get; set; }
    }
}
