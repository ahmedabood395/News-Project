using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LabDay4MVC.Models
{
    public class ChangePassword
    {
        [DisplayName("Old Password")]

        [Required(ErrorMessage ="*")]
        public string password { get; set; }
        [Required(ErrorMessage = "*")]
        [DisplayName("New Password")]

        public string new_password { get; set; }
    }
}