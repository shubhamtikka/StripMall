using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class ShoppingCartItem
    {
        //public Guid ShoppingCartItemId { get; set; }

        [ForeignKey("ApplicationUser")]
        public ApplicationUser Customer { get; set; }

        [Key]
        public string CustomerId { get; set; }

        [Key]
        public string Item { get; set; }

        [Display(Name = "Cart Item")]
        public string ItemName { get; set; }

        public string SellerId { get; set; }

        [Display(Name = "Shop")]
        public string ShopName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Display(Name = "Price")]
        public int ItemPrice { get; set; }

        [Range(1, int.MaxValue)][Display(Name ="Count")]
        public int ItemCount { get; set; }

        [Display(Name = "Total")]
        public int ItemTotal { get; set; }
    }
}


