using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop2.DataAccess.InMemory;
using WebShop2.Core.Models;
using WebShop2.Core.ViewModels;

namespace WebShop2.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        public ProductRepository context;
        public ProductCategoryViewModel categories;
        public ProductCategoryRepository categoryContext;
        // GET: ProductManager
        public ProductManagerController()
        {
            context = new ProductRepository();
            categories = new ProductCategoryViewModel();
            categoryContext = new ProductCategoryRepository();
        }
        public ActionResult Index()
        {
            if (context.products == null)
            {
                context.products = new List<Product>();
            }
            
            /*Product product = new Product();
            product.Name = "Superman";
            product.Category = "Toy";
            product.Price = 1000;
            context.AddProduct(product);*/
            context.Commit();
            context.products.ToList<Product>();
            context.Collection();
            return View(context.products);
        }

        public ActionResult Create()
        {
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();
            productCategoryViewModel.Product = new Product();
            productCategoryViewModel.Categories = categoryContext.productCategories;
            productCategoryViewModel.Categories.AsQueryable();
            Product product = new Product();
            return View(productCategoryViewModel);
            
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                context.AddProduct(product);
                context.Commit();
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(Product product)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string id, Product product)
        {
            ProductCategoryViewModel productViewModel = new ProductCategoryViewModel();
            productViewModel.Product = context.products.Find(p=>p.ID==id);
            productViewModel.Categories = categoryContext.productCategories.ToList().AsQueryable();
            productViewModel.Product.Name = product.Name;
            productViewModel.Product.Price = product.Price;
            productViewModel.Product.Category = product.Category;
            productViewModel.Product.Image = product.Image;
            context.Commit();
            return RedirectToAction("Index");
        }
    }
}