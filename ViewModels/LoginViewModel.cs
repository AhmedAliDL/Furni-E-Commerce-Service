using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.ViewModels
{
    public class LoginViewModel
    {
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[cC][oO][mM]$", ErrorMessage = "Email must end with .com")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
