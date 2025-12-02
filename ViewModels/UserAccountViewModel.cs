using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.ViewModels
{
    public class UserAccountViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }
}
