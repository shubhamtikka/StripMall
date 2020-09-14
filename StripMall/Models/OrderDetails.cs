using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{ 
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Orders")]
        public Orders Order { get; set; }
        public string OrderId { get; set; }

        public string SellerId { get; set; }

        [Display(Name = "Shop")]
        public string ShopName { get; set; }

        [Display(Name ="Item")]
        public string ItemName { get; set; }

        [Display(Name = "Price")]
        public int ItemPrice { get; set;   }

        [Display(Name = "Count")]
        public int ItemCount { get; set; }

        [Display(Name = "Total")]
        public double ItemTotal { get; set; }
    }
}