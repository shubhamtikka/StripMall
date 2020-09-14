using Microsoft.AspNetCore.Http;
using StripMall.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.ViewModels
{
    public class AddItemsViewModel : Items
    {
        [Required]
        public int Category { get; set; }

        public IFormFile ItemPhoto { get; set; }
    }
}
