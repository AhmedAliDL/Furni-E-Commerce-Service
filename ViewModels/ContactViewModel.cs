using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.ViewModels
{
    public class ContactViewModel
    {
        [MinLength(3)]
        [MaxLength(40)]
        public string Subject { get; set; }
        [MinLength(5)]
        public string Body { get; set; }
    }
}
