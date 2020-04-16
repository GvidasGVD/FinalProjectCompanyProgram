﻿using System.ComponentModel.DataAnnotations;

namespace FinalProjectCompanyProgram.Models
{

    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        //public string LastName { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}