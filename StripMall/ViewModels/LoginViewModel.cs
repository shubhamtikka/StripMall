﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="Mail id is required")]
        public string EmailId { get; set; }

        [Required (ErrorMessage ="Enter your password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
