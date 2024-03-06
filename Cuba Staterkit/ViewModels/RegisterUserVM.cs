using System.ComponentModel.DataAnnotations;

namespace SmartHome_Project.ViewModels
{
    public class RegisterUserVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
