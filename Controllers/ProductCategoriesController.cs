using System.Collections;
using Microsoft.AspNetCore.Mvc;
using TestHtt.Models;
using TestHtt.Services;

namespace TestHtt.Controllers
{
    public class ProductCategoriesController : Controller
    {
        public IActionResult Index()
        {
            var service = new ProductCategoryService<ProductCategoriesModel>();
            return View(service.GetCategories());
        }

        public IActionResult EditResult(int CategoryId, string CategoryName, string CategoryDescription)
        {
            var service = new ProductCategoryService<ProductCategoriesModel>();

            service.Update("ProductCategoryUpdate",
                new[] { "@value1", "@value2", "@position" }, 
                new object[] { CategoryName, CategoryDescription, CategoryId });

                return View("Index",service.GetCategories());
        }

        public IActionResult EditForm()
        {
            return View();
        }
    }
}
