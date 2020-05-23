using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideosManagementSystem.Core
{
    public class Login
    {
        [Required(ErrorMessage = "Enter an existing username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter a valid Password")]
        public string Password { get; set; }
    }
}
