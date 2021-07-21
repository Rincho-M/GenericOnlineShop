using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [UIHint("EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 32 characters long.")]
        [UIHint("Password")]
        public string Password { get; set; }
    }
}
