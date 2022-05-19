using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TISklep.ViewModels
{
    public class RegisterViewModel
    {   [Required(ErrorMessage = "Wprowadź email")]
        [EmailAddress(ErrorMessage ="Niepoprawny foramt!")]
        public string Email { get; set; }
        [Required(ErrorMessage= "Wprowadz login!")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Podaj Imię!")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Podaj nazwisko"]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Wprowadz hasło!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Wprowadz poprawne hasło!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Hasła musza być jednakowe!")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage ="Podaj login!")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Podaj hasło!")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
