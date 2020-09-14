using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CustomerId { get; set; }

        [Required(ErrorMessage ="feeback cannot be empty!")]
        public string FeedBackText { get; set; }
        public DateTime Date { get; set; }
    }
}
