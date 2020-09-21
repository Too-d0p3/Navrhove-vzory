using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class LoginForm
    {
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Heslo")]
        [Required]
        public string Password { get; set; }
    }
}
