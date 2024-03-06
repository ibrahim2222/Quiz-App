using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cuba_Staterkit.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
