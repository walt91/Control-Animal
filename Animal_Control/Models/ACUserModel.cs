using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Animal_Control.Models
{
    public class ACUserModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(200)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
    }
}