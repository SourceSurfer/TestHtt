﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using TestHtt.Models;
using TestHtt.Services;

namespace TestHtt.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
           

            return View();
        }
    }
}
