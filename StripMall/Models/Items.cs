using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class Items
    {
        [Key]
        public Guid ItemsId { get; set; }

        [ForeignKey("ApplicationUser")]
        public ApplicationUser Seller { get; set; }
        public string Id { get; set; }

        [ForeignKey("Category")]
        public Category category { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int ItemPrice { get; set; }

        public string ItemDesc { get; set; }

        public string ItemWeight { get; set; }
        public string PhotoPath { get; set; }

        public bool IsInStock { get; set; }
    }

}
