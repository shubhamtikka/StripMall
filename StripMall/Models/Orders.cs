using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StripMall.Models
{
    public class Orders
    {
        public static long GenerateOrderId()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt16(buffer, 0);
        }

        [Key]
        public string OrderId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string AppUserId { get; set; }

        public double OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
