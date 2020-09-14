using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }


        [Required]
        public virtual string LocationName { get; set; }
        [Required]
        public long TLChatId { get; set; }
        [Required]
        public  string TLToken { get; set; }

    }
}
