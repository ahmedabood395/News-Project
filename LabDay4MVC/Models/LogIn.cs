using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LabDay4MVC.Models
{
    public class LogIn
    {
        [Required(ErrorMessage = "*")]

        public string Email { get; set; }
        [Required(ErrorMessage = "*")]

        public string Password { get; set; }
    }
}