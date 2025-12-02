using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.ViewModels
{
    public class RegisterViewModel
    {
        [MaxLength(30)]
        [MinLength(3)]
        public string FName { get; set; }
        [MaxLength(30)]
        [MinLength(3)]
        public string LName { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[cC][oO][mM]$", ErrorMessage = "Email must end with .com")]
        public string Email { get; set; } 
        [MaxLength(11)]
        [MinLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [MaxLength(120)]
        public string Country { get; set; }
        [MaxLength(80)]
        public string City { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirmed Password field must match Password field")]
        public string ConfirmPassword { get; set; }
    }
}
