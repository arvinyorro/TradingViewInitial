using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Initial.Models
{
    public class AddIndicatorModel
    {
        [Required]
        public long BatchId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TimeInterval { get; set; }

        [Required]
        public string Direction { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
