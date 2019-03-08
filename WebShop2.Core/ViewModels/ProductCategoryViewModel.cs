using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop2.Core.Models;

namespace WebShop2.Core.ViewModels
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
    }
}
