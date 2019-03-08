using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop2.DataAccess.InMemory;
using WebShop2.Core.Models;


namespace WebShop2.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        public ProductRepository context;
        // GET: ProductManager
        public ProductManagerController()
        {
            context = new ProductRepository();
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
            return View();
            
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
            
            Product productToEdit = context.products.Find(p=>p.ID==id);
            productToEdit.Name = product.Name;
            productToEdit.Price = product.Price;
            productToEdit.Category = product.Category;
            productToEdit.Image = product.Image;
            context.Commit();
            return RedirectToAction("Index");
        }
    }
}