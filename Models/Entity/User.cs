using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TECHNICAL_ASSESSMENT.Models.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Choose the role for this user")]
        [EnumDataType(typeof(RoleValue))]
        [Range(1, 3,ErrorMessage = "Choose any role")]
        public RoleValue RoleId { get; set; }

        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter valid password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password should be one special character")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please enter valid mobile number")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Pic the date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }        
    }
    public enum RoleValue
    {
        Admin = 1,
        Doctor = 2,
        Patient = 3
    }
}