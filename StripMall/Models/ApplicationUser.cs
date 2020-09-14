using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [ForeignKey("Location")]
        public Location UserLocation { get; set; }
        public string LocName { get; set; }

        public string AddrLine1 { get; set; }
        public string AddrLine2 { get; set; }
        public int PinCode { get; set; }


        public string ShopName { get; set; }
        [ForeignKey("ShopType")]
        public ShopType shopType { get; set; }
        public string TypeName { get; set; }
        public bool IsShopOpen { get; set; }
        public string PhotoPath { get; set; }
    }
}
