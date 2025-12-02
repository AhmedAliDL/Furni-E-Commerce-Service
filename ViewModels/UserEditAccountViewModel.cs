using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.ViewModels
{
    public class UserEditAccountViewModel
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [MaxLength(120)]
        public string? Country { get; set; }
        [MaxLength(80)]
        public string? City { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }

    }
}
