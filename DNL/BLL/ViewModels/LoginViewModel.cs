using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [UIHint("email")]
        public string Email { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
