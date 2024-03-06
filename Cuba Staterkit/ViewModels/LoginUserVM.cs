﻿using System.ComponentModel.DataAnnotations;

namespace SmartHome_Project.ViewModels
{
    public class LoginUserVM
    {
        [Required]

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
