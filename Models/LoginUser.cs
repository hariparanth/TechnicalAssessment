using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TECHNICAL_ASSESSMENT.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]        
        public string Password { get; set; }
    }
}