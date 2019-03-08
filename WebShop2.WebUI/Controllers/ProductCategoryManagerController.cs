using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop2.Core.Models;
using WebShop2.DataAccess.InMemory;

namespace WebShop2.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        public ProductCategoryRepository context;
        // GET: ProductManager
        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepository();
        }
        public ActionResult Index()
        {
            if (context.productCategories == null)
            {
                context.productCategories = new List<ProductCategory>();
            }

            /*Product product = new Product();
            product.Name = "Superman";
            product.Category = "Toy";
            product.Price = 1000;
            context.AddProduct(product);*/
            context.Commit();
            context.productCategories.ToList<ProductCategory>();
            context.Collection();
            return View(context.productCategories);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                context.AddProductCategory(productCategory);
                context.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(ProductCategory productCategory)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string id, ProductCategory productCategory)
        {

            ProductCategory productCategoryToEdit = context.productCategories.Find(p => p.ID == id);
            
            productCategoryToEdit.Category = productCategory.Category;
            
            context.Commit();
            return RedirectToAction("Index");
        }
    }
}