﻿using System.ComponentModel.DataAnnotations;

namespace HernandezITELEC1C.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "A user name is required")]
        public string? UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A password is required")]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please confirm your password")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        [Required(ErrorMessage = "A phone number is required")]
        public string? Phone { get; set; }

    }
}
