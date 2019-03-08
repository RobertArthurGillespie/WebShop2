using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop2.Core.Models
{
    public class Product
    {
        public string ID { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Range(1,1000)]
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        public string Image { get; set; }

        public Product()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }

    
}
