using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.Models
{
    public class User : IdentityUser
    {
        [MaxLength(20)]
        public string FName { get; set; }
        [MaxLength(20)]
        public string LName {  get; set; }
        [MaxLength(120)]
        public string Country { get; set; }
        [MaxLength(80)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        

       
    }
}
