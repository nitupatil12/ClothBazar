﻿using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryservice = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoryservice.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryservice.SaveCategory(category ); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category=categoryservice.GetCategory(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryservice.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            var category = categoryservice.GetCategory(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {            
            categoryservice.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }
    }
}