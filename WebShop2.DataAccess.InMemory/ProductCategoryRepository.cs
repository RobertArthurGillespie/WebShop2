using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using WebShop2.Core.Models;

namespace WebShop2.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        public ObjectCache cache = MemoryCache.Default;
        public List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }

            productCategories = cache["productCategories"] as List<ProductCategory>;
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Collection()
        {
            productCategories.AsQueryable();
        }
    }
}
