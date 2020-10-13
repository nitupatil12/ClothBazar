using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsSevices = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult ProductTable(string serach)
        {
            var Products = productsSevices.GetProducts();
            if(string.IsNullOrEmpty(serach)==false)
            {
                Products = Products.Where(p => p.Name != null && p.Name.ToLower().Contains(serach.ToLower())).ToList();
            }
            return PartialView(Products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsSevices.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productsSevices.GetProduct(ID);
            return PartialView(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productsSevices.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        public ActionResult Delete(int ID)
        {
            productsSevices.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}