﻿using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.web.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
    }
}