using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class Cart
    {
        [ForeignKey("ApplicationUser")]
        public ApplicationUser Customer { get; set; }

        [Key]
        public string AppUserId { get; set; }

        [Key]
        public string Item { get; set; }
        
        //[ForeignKey("ApplicationUser")]
        public string SellerId { get; set; }

        public int ItemPrice { get; set; }

        public int ItemCount { get; set; }

        public int ItemTotal { get; set; }
    }
}
