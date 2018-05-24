using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SurvivorLeague.Models
{
    public class AccountRegistrationViewModel
    {
        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("Birthdate")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "REQUIRED")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "REQUIRED")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"
            , ErrorMessage = "Password is at least 8 characters with at Least 1 Uppercase, 1 Lowercase, and 1 Number")]
         [Compare("ConfirmPassword", ErrorMessage = "Passwords don't match")]
       [PasswordPropertyText]
        public string Password { get; set; }

        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("Confirm Password")]
        [PasswordPropertyText]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("Password Hint")]
        public string PasswordHint { get; set; }

        public AccountRegistrationViewModel(string firstName, string lastName, DateTime dateOfBirth, string email, string password, string confirmPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            Password = password;
        }

        public AccountRegistrationViewModel()
        {

        }
    }
}