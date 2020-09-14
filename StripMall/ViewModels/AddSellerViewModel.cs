using Microsoft.AspNetCore.Http;
using StripMall.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.ViewModels
{
    public class AddSellerViewModel 
    {
        [Required]
        public string ShopName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password did not match!")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public Guid location { get; set; }

        [Required]
        public int shopType { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public int PinCode { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFile ShopPhoto { get; set; } 


    }
}
