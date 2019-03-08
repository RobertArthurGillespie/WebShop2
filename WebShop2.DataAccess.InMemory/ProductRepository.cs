using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using WebShop2.Core.Models;

namespace WebShop2.DataAccess.InMemory
{
    public class ProductRepository
    {
        public ObjectCache cache = MemoryCache.Default;
        public List<Product> products;
        
        public ProductRepository()
        {
            if (products == null)
            {
                products = new List<Product>();
            }
            
            products = cache["products"] as List<Product>;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Collection()
        {
            products.AsQueryable();
        }
    }
}
