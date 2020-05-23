using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VideosManagementSystem.Core
{
    public class Users
    {
        [Key]
        [Required(ErrorMessage = "Please enter a user_name")]
        [StringLength(20, ErrorMessage = "Minimum 5 and maximum 20 characters only", MinimumLength = 5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your full name")]
        [StringLength(30, ErrorMessage = "Minimum 3 and maximum 30 characters only", MinimumLength = 3)]
        public string FullName { get; set; }
        
        public string ProfilePicture { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter your email address")]
        [RegularExpression(@"^[a-z0-9._]+@[a-z0-9.-]+.[a-z]{2,4}$", ErrorMessage = "Please enter a valid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(30, ErrorMessage = "Your passsword should be atleast 8 characters long", MinimumLength = 8)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [Compare("Password", ErrorMessage ="Password and confirm password should be same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter a valid mobile no.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "The phone number should be 10 digits")]
        public long PhoneNo { get; set; }

        [Required(ErrorMessage = "Enter your address")]
        [StringLength(500)]
        public string Address { get; set; }
       
    }
}
