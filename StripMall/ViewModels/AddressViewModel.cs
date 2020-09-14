using StripMall.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.ViewModels
{
    public class AddressViewModel 
    {
        [Required]
        public Guid location { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public int PinCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
